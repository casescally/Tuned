
import React, { useState, useEffect } from "react"

/*

    The context is imported and used by individual components

    that need data

*/

export const EventContext = React.createContext()

/*

 This component establishes what data can be used.

 */

export const EventProvider = (props) => {

    const [events, setEvents] = useState([])

    const getEvents = () => {

        return fetch("http://localhost:5000/events")

            .then(res => res.json())

            .then(setEvents)

    }

    const addEvent = event => {

        return fetch("http://localhost:5000/events", {

            method: "POST",

            headers: {

                "Content-Type": "application/json"

            },

            body: JSON.stringify(event)

        })

            .then(getEvents)

    }

    const deleteEvent = event => {

        return fetch(`http://localhost:5000/events/${event.id}`, {

            method: "DELETE"

        })

            .then(getEvents)

    }

    const updateEvent = event => {

        return fetch(`http://localhost:5000/events/${event.id}`, {

            method: "PUT",

            headers: {

                "Content-Type": "application/json"

            },

            body: JSON.stringify(event)

        })

            .then(getEvents)

    }

    /*

        Load all events when the component is mounted. Ensure that

        an empty array is the second argument to avoid infinite loop.

    */

    useEffect(() => {

        getEvents()

    }, [])

    useEffect(() => {

        // console.log("****  EVENT APPLICATION STATE CHANGED  ****")

        // console.log(events)

    }, [events])

    return (

        <EventContext.Provider value={{

            events, addEvent, deleteEvent, updateEvent

        }}>

            {props.children}

        </EventContext.Provider>

    )

}