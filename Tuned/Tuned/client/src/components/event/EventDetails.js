import React, { useContext, useState, useEffect } from "react"
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import interactionPlugin from '@fullcalendar/interaction';
import { UserContext } from "../user/UserProvider"
import { EventContext } from "./EventProvider"
import { getUser } from "../../API/userManager"
import { UserEventContext } from "../UserEvent/UserEventProvider"
import {Map, Marker, GoogleApiWrapper} from 'google-maps-react';
import UserCard from "../user/User"
import "./Events.css"
import './EventDetails.css'

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
    const eventUser = users.find(u => u.id === event.applicationUserId) || {}
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
        //console.log('google maps geocode==>>', props.google.maps.Geocoder)
        if (event.location) {
            fetch(`https://maps.googleapis.com/maps/api/geocode/json?address=${event.location}&key=${process.env.REACT_APP_GOOGLE_API_KEY}`)
            .then(res => res.json())
            .then(res => {
            //console.log('google maps geocode ress==>>', res);
                setEventGeoLocation(res.results[0].geometry.location)
            }).catch(err => console.log('Error:', err));
        }
        
    }, [event])

//console.log('event==>>', event)

const onMarkerClick = () => {

}

    return (
        <section className="event">
            
                    {eventImages.map((image, i) => <img key={i} src={`https://localhost:5001/api/EventImages/image/get?imageName=${image}`} className="event_image" alt="Event"/>)}


        <div  className="map-container">
                    {eventGeoLocation && <Map
                    initialCenter={eventGeoLocation}
          google={props.google}
          zoom={5}
          ><iframe title="eventLocationMapFrame" width="425" height="350" frameBorder="0" scrolling="no" marginHeight="0" marginWidth="0" ></iframe>

                <Marker position={eventGeoLocation} onClick={onMarkerClick}
                        name={'Current location'} />

                </Map>}
            </div>

            <div id="calendar">
            <FullCalendar
        plugins={[ dayGridPlugin ]}
        defaultDate={event.date}
        events={[{title: event.name, date: event.date}]}
      />
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