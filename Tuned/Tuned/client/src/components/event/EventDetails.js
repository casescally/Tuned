import React, { useContext, useState, useEffect } from "react"
import { UserContext } from "../user/UserProvider"
import { EventContext } from "./EventProvider"
import "./Events.css"
import { getUser } from "../../API/userManager"

export default (props) => {

    const { events, deleteEvent } = useContext(EventContext)
    const [eventImages, setEventImages] = useState([])
    const { users } = useContext(UserContext)

    const chosenEventId = parseInt(props.match.params.eventId, 10)

    const user = getUser()
    const event = events.find(c => c.id === chosenEventId) || {}
    //const likedEvent = likedEvents.find(l => l.likedEventId === event.id) || {}
    const eventUser = users.find(u => u.id === event.applicationUserId) || {}
    //const currentUsersEvents = events.filter(c => c.userId === user.id)
    let likedEventMode = Boolean
    useEffect(() => {
        const images = event.imagePath;
        if (images) setEventImages(JSON.parse(images))
    }, [event])

console.log(event)
    return (
        <section className="event">
                    {eventImages.map((image, i) => <img key={i} src={`https://localhost:5001/api/EventImages/image/get?imageName=${image}`} alt="Image of event"/>)}
            <h3 className="event__name">{event.name}</h3>

            <button className="likeButton" value="Like" onClick={evt => {

                evt.preventDefault()

                // constructNewLike(event)

            }

            }>{likedEventMode ? "Like" : "Unlike"}</button>

            <div className="event__user">User: {eventUser.username}</div>
            
            <button onClick={
                () => {

                    deleteEvent(event)
                        .then(() => {
                            props.history.push("/events")
                        })
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