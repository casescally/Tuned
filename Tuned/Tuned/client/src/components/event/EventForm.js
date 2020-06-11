import React, { useContext, useState, useEffect, useReducer } from "react"
import { EventContext } from "./EventProvider"
import { getUser } from "../../API/userManager"
//import { LikedEventContext } from "../likedEvent/LikedEventProvider"
import { createAuthHeaders } from "../../API/userManager"
import "./Events.css"

export default props => {
 
    const user = getUser();

    // const { likedEvents } = useContext(LikedEventContext)

    const { events, addEvent, saveImages, updateEvent } = useContext(EventContext)

    const [event, setEvent] = useState({})

    const editMode = props.match.params.hasOwnProperty("eventId")

    const handleControlledInputChange = (event) => {
        /*
            When changing a state object or array, always create a new one
            and change state instead of modifying current one
        */
        const newEvent = Object.assign({}, event)
        newEvent[event.target.name] = event.target.value
        setEvent(newEvent)
    }

    const imageFileChanged = async (event) => {
        console.log(event.target.files);
        const filePaths = await saveImages(event.target.files);
        event['imageFilePaths'] = filePaths;

        //for loop  filePaths.split(','); => arrray of base64 images.
        console.log(event);
        setEvent(event);
        setEvent({
            imageSrc: filePaths
         })
        // const newEvent = Object.assign({}, event)
        // newEvent['imageFile'] = event.target.files[0];
        // setEvent(newEvent);
    }

    const setDefaults = () => {
        if (editMode) {
            const eventId = parseInt(props.match.params.eventId)
            const selectedEvent = events.find(a => a.id === eventId) || {}
            setEvent(selectedEvent)
        }
    }

    useEffect(() => {
        setDefaults()
    }, [events])

    const getImageSrc = () => {
    //console.log('Called');
    //console.log(event.imageFilePaths);

     return 'data:image/jpeg;base64,' + event.imageFilePaths;  //event.imageFilePaths[index]
     //event.defaultImage = event.imageFilePaths[0];
    };

    const constructNewEvent = () => {

        if (editMode) {

            updateEvent({

                id: event.id,
                name: event.name,
                locaiton: event.location,
                date: event.date,
                description: event.description,
                imagePath: event.imagePath,
                activeEvent: event.activeEvent,
                userId: event.userId,
                adminUser: event.adminUser

            })

                .then(() => props.history.push("/events"))

        } else {

            addEvent({

                id: event.id,
                name: event.name,
                locaiton: event.location,
                date: event.date,
                description: event.description,
                imagePath: event.imagePath,
                activeEvent: event.activeEvent,
                userId: event.userId,
                adminUser: event.adminUser,
                imageFile: event.imageFile
            })
                //console.log(event)

                .then(() => props.history.push("/events"))
        }
    }

    // async function sendImage(event) {
    //     event.preventDefault();
    //     console.log(this.state.file);
    //     await this.addImage(this.state.file);
    //     console.log('it works');
    // };
    // async function addImage(image) {
    //     const authHeader = createAuthHeaders();
    //     await fetch('https://localhost:44385/api/events',

    //         {

    //             method: 'POST',
    //             mode: 'cors',
    //             headers: {
    //                 //'Accept': 'application/json',
    //                 //'Authorization': 'Bearer ' + sessionStorage.tokenKey
    //                 headers: authHeader
    //             },
    //             body: this.state.file
    //         }
    //     )
    // }

    // async function handleImageChange(e) {
    //     e.preventDefault();
    //     let form = new FormData();
    //     for (var index = 0; index < e.target.files.length; index++) {
    //         var element = e.target.files[index];
    //         form.append('image', element);
    //     }
    //     form.append('fileName', "Img");
    //     this.setState({ file: form });
    // };

    return (
        <form className="eventForm">
            <h2 className="eventForm__title">{editMode ? "Update Event" : "Add Event"}</h2>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="name">Event name: </label>
                    <input type="text" name="name" required autoFocus className="form-control"
                        proptype="varchar"
                        placeholder="Event name"
                        defaultValue={event.name}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="make">Event make: </label>
                    <input type="text" name="make" required className="form-control"
                        proptype="varchar"
                        placeholder="Event make"
                        defaultValue={event.make}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="model">Event model: </label>
                    <input type="text" name="model" required className="form-control"
                        proptype="varchar"
                        placeholder="Event model"
                        defaultValue={event.model}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="year">Event year: </label>
                    <input type="text" name="year" required className="form-control"
                        proptype="varchar"
                        placeholder="Event year"
                        defaultValue={event.year}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="vehicleTypeId">Vehicle Type: </label>
                    <input type="text" name="vehicleTypeId" required className="form-control"
                        proptype="varchar"
                        placeholder="Vehicle Type"
                        defaultValue={event.vehicleTypeId}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="eventPageCoverUrl">Event Page Cover: </label>
                    <input type="text" name="eventPageCoverUrl" required className="form-control"
                        proptype="varchar"
                        placeholder="Event Page Cover"
                        defaultValue={event.eventPageCoverUrlId}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <form method="post" encType="multipart/form-data" action="https://localhost:5001/api/events" required className="form-control">
                <div>
                    <label htmlFor="imageFile">Image File</label>
                    <input name="imageFile" type="file" multiple onChange={imageFileChanged} />
                    <div className="imagePreview" id="imagePreview">
                        <img src={event.imageSrc} ></img>
                       <span class="image-preview__default-text">Image Preview</span>
                    </div>
                </div>
                <div>
                    <input type="submit" value="Submit" />
                </div>
            </form>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="description">Description: </label>
                    <textarea type="text" name="description" className="form-control"
                        proptype="varchar"
                        value={event.description}
                        onChange={handleControlledInputChange}>
                    </textarea>
                </div>
            </fieldset>
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