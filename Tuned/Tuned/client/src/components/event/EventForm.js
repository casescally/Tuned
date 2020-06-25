import React, { useContext, useState, useEffect } from "react"
import { EventContext } from "./EventProvider"
import { getUser } from "../../API/userManager"

import "./Events.css"

export default props => {

    const user = getUser();
    const { events, addEvent, saveImages, updateEvent } = useContext(EventContext)
    const [createdEvent, setCreatedEvent] = useState({})
    const [eventImage, setEventImage] = useState("")
    const editMode = props.match.params.hasOwnProperty("eventId")
    const handleControlledInputChange = (event) => {

        /*
            When changing a state object or array, always create a new one
            and change state instead of modifying current one
        */

        const newEvent = Object.assign({}, createdEvent)
        newEvent[event.target.name] = event.target.value
        setCreatedEvent(newEvent)
    }


    const imageFileChanged = async (event) => {

        const eventImageURL = URL.createObjectURL(event.target.files[0])

        setEventImage(eventImageURL)

        const filePaths = await saveImages(event.target.files);
        const newEvent = {
            ...createdEvent,
            imagePath: filePaths,
            eventPageCoverUrl: filePaths.split(',')[0]
        }

        setCreatedEvent(newEvent);
    }

    const setDefaults = () => {
        if (editMode) {
            const eventId = parseInt(props.match.params.eventId)
            const selectedEvent = events.find(a => a.id === eventId) || {}
            setCreatedEvent(selectedEvent)
            getImageSrc(selectedEvent)
        }
    }

    useEffect(() => {
        setDefaults()
    }, [events])

    const getImageSrc = (currentEvent) => {

        if (currentEvent.imagePath) {

            fetch(`https://localhost:5001/api/EventImages/image/get?imageName=${JSON.parse(currentEvent.imagePath)[0].split("/")}`).then(res => res.blob()).then(a => {
                setEventImage(URL.createObjectURL(a))
                console.log('a==>>', currentEvent.imagePath)
            })
        }

    };

    /*
    React relies on data flow, you should always update your "state" based on the state of the information of the app.
    server call > response from server > update the state with data from server > view is re-rendered with new data.
    */

    const constructNewEvent = () => {

        if (editMode) {

            updateEvent({
                id: createdEvent.id,
                name: createdEvent.name,
                location: createdEvent.location,
                date: createdEvent.date,
                description: createdEvent.description,
                adminUserId: user.id,
                activeEvent: true,
                userId: user.id,
                imagePath: createdEvent.imagePath
            })

                .then(data => {
                    getImageSrc(createdEvent)
                    props.history.push("/events")
                })

        } else {

            addEvent({

                name: createdEvent.name,
                location: createdEvent.location,
                date: createdEvent.date,
                description: createdEvent.description,
                imagePath: createdEvent.imagePath,
                activeEvent: true,
                adminUserId: user.id,
                userId: user.id

            })
                .then(() => props.history.push("/events"))
        }
    }

    return (
        <form className="eventForm">
            <h2 className="eventForm__title">{editMode ? "Update Event" : "Add Event"}</h2>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="name">Event name: </label>
                    <input type="text" name="name" required autoFocus className="form-control"
                        proptype="varchar"
                        placeholder="Event name"
                        value={createdEvent.name}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="location">Event location: </label>
                    <input type="text" name="location" required className="form-control"
                        proptype="varchar"
                        placeholder="Event location"
                        value={createdEvent.location}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="description">Event description: </label>
                    <input type="text" name="description" required className="form-control"
                        proptype="varchar"
                        placeholder="Event description"
                        value={createdEvent.description}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="date">Event date: </label>
                    <input type="date" name="date" required className="form-control"
                        proptype="varchar"
                        placeholder="Event date"
                        value={createdEvent.date}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <form method="post" required className="form-control">
                <div>
                    <label htmlFor="imageFile">Image File</label>
                    <input name="imageFile" type="file" multiple onChange={imageFileChanged} />
                    <div className="imagePreview" id="imagePreview">
                        <img className="event_preview_image" src={eventImage} />
                        <span class="image-preview__default-text">Image Preview</span>
                    </div>
                </div>
            </form>
            <button type="submit"
                onClick={evt => {
                    evt.preventDefault()
                    constructNewEvent()
                }}
                className="btn btn-primary">
                {editMode ? "Save Updates" : "Add Event"}
            </button>
        </form>
    )
}