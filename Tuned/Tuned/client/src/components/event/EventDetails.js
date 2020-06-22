import React, { useContext, useState, useEffect } from "react"
import { UserContext } from "../user/UserProvider"
import { EventContext } from "./EventProvider"
import "./Events.css"
import { getUser } from "../../API/userManager"
import { UserEventContext } from "../UserEvent/UserEventProvider"
import {Map, InfoWindow, Marker, GoogleApiWrapper} from 'google-maps-react';
import UserCard from "../user/User"

const EventDetails = (props) => {
    const { events, deleteEvent } = useContext(EventContext)
    const { userEvents, addUserEvent, deleteUserEvent } = useContext(UserEventContext)
    const [eventImages, setEventImages] = useState([]);
    const [eventGeoLocation, setEventGeoLocation] = useState(null);
    const [addedUserEventMode, setAddedUserEventMode] = useState(true);
    const { users } = useContext(UserContext)
    const chosenEventId = parseInt(props.match.params.eventId, 10)
    const user = getUser()
    const event = events.find(c => c.id === chosenEventId) || {}
    //const likedEvent = likedEvents.find(l => l.likedEventId === event.id) || {}
    const eventUser = users.find(u => u.id === event.applicationUserId) || {}
    //const currentUsersEvents = events.filter(c => c.userId === user.id)
    //const eventUsers = userEvents.filter(userEvent => userEvent.eventId === event.id && userEvent.applicationUser.id)
    let currentEventUsers = []
    
    {
        userEvents.forEach(rel => {

            const foundUser = users.filter(
                (singleUser) => {
                    return rel.applicationUser.id === singleUser.id && rel.eventId === event.id
                }
            )[0]

            if (foundUser) {
            currentEventUsers.push(foundUser)

            }

        })
    }
    console.log('users==>>', currentEventUsers)
    const constructNewUserEvent = (currentEvent) => {

        const alreadyAddedEventRel = userEvents.find(userEvent => userEvent.eventId === currentEvent.id && userEvent.applicationUser.id === user.id)

        //Don't allow duplicate added events
    
        if (alreadyAddedEventRel) {

            deleteUserEvent(alreadyAddedEventRel)
            setAddedUserEventMode(true)

        } else {

            addUserEvent({
                eventId: currentEvent.id,
                userId: user.id
            })

            setAddedUserEventMode(false);
        }            
    }

    useEffect(() => {
        const images = event.imagePath;
        if (images) setEventImages(JSON.parse(images))
        console.log('google maps geocode==>>', props.google.maps.Geocoder)
        if (event.location) {
            fetch(`https://maps.googleapis.com/maps/api/geocode/json?address=${event.location}&key=${process.env.REACT_APP_GOOGLE_API_KEY}`)
            .then(res => res.json())
            .then(res => {
                console.log('google maps geocode ress==>>', res);
                setEventGeoLocation(res.results[0].geometry.location)
            }).catch(err =>console.log('errr==>>', err));
            /*props.google.maps.Geocoder.geocode({location: event.location}, result => {
                
            })*/
        }
        
    }, [event])

console.log('event==>>', event)

const onMarkerClick = () => {

}

const onInfoWindowClose = () => {

}
console.log("test", event)
    return (
        <section className="event">
            
                    {eventImages.map((image, i) => <img key={i} src={`https://localhost:5001/api/EventImages/image/get?imageName=${image}`} className="event_image" alt="Image of event"/>)}


        <div  className="map-container">
                    {eventGeoLocation && <Map
                    initialCenter={eventGeoLocation}
          google={props.google}
          zoom={5}
          ><iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" ></iframe>

                <Marker position={eventGeoLocation} onClick={onMarkerClick}
                        name={'Current location'} />

                    {/*<InfoWindow onClose={onInfoWindowClose}>
                    <div>
                    <h1>{'yoo'}</h1>
                    </div>
                    </InfoWindow>*/}
                </Map>}
            </div>

            <h3 className="event__name">{event.name}</h3>

                <p className="event_description">
                    {event.description}
                </p>

            <button className="add/remove_Button" value="add/remove" onClick={evt => {

                evt.preventDefault()

                constructNewUserEvent(event)

            }

            }>{addedUserEventMode ? "Add" : "Remove"}</button>

            <div className="event_admin_user">{eventUser.adminUser ? `Admin: ${eventUser.username}` : ""}</div>

            <article className="event_users">
                        <h3>Users: {currentEventUsers.length}</h3>

                        {currentEventUsers.map(user => <UserCard key={user.id} user={user} {...props} />)}

                    </article>
            
            <button onClick={
                () => {
                    if (event.adminUser.id === user.id) {
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

export default GoogleApiWrapper({
    apiKey: (process.env.REACT_APP_GOOGLE_API_KEY)
  })(EventDetails)