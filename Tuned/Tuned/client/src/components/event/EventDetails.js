import React, { useContext, useState, useEffect } from "react"
import { UserContext } from "../user/UserProvider"
import { EventContext } from "./EventProvider"
import "./Events.css"
import { getUser } from "../../API/userManager"
import { UserEventContext } from "../UserEvent/UserEventProvider"

export default (props) => {

    const { events, deleteEvent } = useContext(EventContext)
    const { userEvents, addUserEvent, deleteUserEvent } = useContext(UserEventContext)
    const [eventImages, setEventImages] = useState([])
    const { users } = useContext(UserContext)
    const chosenEventId = parseInt(props.match.params.eventId, 10)

    const user = getUser()
    const event = events.find(c => c.id === chosenEventId) || {}
    //const likedEvent = likedEvents.find(l => l.likedEventId === event.id) || {}
    const eventUser = users.find(u => u.id === event.applicationUserId) || {}
    //const currentUsersEvents = events.filter(c => c.userId === user.id)
    let addedUserEventMode = Boolean
    const constructNewUserEvent = (currentEvent) => {

        const alreadyAddedEventRel = userEvents.find(userEvent => userEvent.eventId === currentEvent.id && userEvent.applicationUser.id === user.id)

        //Don't allow duplicate added events

        if (alreadyAddedEventRel === undefined || null) {

            addUserEvent({

                eventId: currentEvent.id,

                userId: user.id

            })

            addedUserEventMode = false

            console.log(addedUserEventMode)
            console.log(userEvents)

        } else {

            deleteUserEvent(alreadyAddedEventRel)

        }            
        
        addedUserEventMode = true
        console.log(userEvents)
        console.log(addedUserEventMode)

    }




    useEffect(() => {
        const images = event.imagePath;
        if (images) setEventImages(JSON.parse(images))
    }, [event])

console.log(event)

    return (
        <section className="event">
                    {eventImages.map((image, i) => <img key={i} src={`https://localhost:5001/api/EventImages/image/get?imageName=${image}`} alt="Image of event"/>)}
            <h3 className="event__name">{event.name}</h3>

            <button className="add/remove_Button" value="add/remove" onClick={evt => {

                evt.preventDefault()

                constructNewUserEvent(event)

            }

            }>{addedUserEventMode ? "Add" : "Remove"}</button>

            <div className="event__user">User: {eventUser.username}</div>
            
            <button onClick={
                () => {
                    if (event.applicationUserId === user.id) {
                    deleteEvent(event)
                        .then(() => {
                            props.history.push("/events")
                        })
                    }
                }
            }>
                Delete Event

            </button>

            

            <button onClick={() => {
                props.history.push(`/events/edit/${event.id}`)
            }}>Edit
            
            </button>
        </section>
    )
}