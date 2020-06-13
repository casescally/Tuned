import React, { useState, useEffect } from "react"
import { createAuthHeaders } from "../../API/userManager"

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
        const authHeader = createAuthHeaders();
        return fetch("https://localhost:5001/api/events", {
            headers: authHeader
        })
            .then(res => res.json())

            .then(setEvents)

    }

    const saveImages = async (files) => {
        const authHeader = createAuthHeaders();  
        const formData = new FormData();
        if (files) {
          Array.from(files).forEach(file => {
            formData.append(file.name, file);
          });
        }      
        
        const response = await fetch('https://localhost:5001/api/events/files', {
          // content-type header should not be specified!
          method: 'POST',
          headers: {
            authHeader,
          }, 
          body: formData,
          responseType: 'text'
        });
        return response.text();
        //   .then(response => response.text())
        //   .then(filePaths => {
        //     // Do something with the successful response
        //     return filePaths;
        //   })
        //   .catch(error => console.log(error)
        // );
    }

    const addEvent = event => {
        const authHeader = createAuthHeaders();
        return fetch("https://localhost:5001/api/events", {

            method: "POST",

            headers: {
                authHeader,
                "Content-Type": "application/json"

            },

            body: JSON.stringify(event)

        })
            .then(console.log(event))
            .then(getEvents)
    }

    const deleteEvent = event => {
        const authHeader = createAuthHeaders();
        return fetch(`https://localhost:5001/api/events/${event.id}`, {
            headers: authHeader,
            method: "DELETE"

        })

            .then(getEvents)

    }

    const updateEvent = event => {
        const authHeader = createAuthHeaders();
        return fetch(`https://localhost:5001/api/events/${event.id}`, {

            method: "PUT",

            headers: {
                authHeader,
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

            events, addEvent, deleteEvent, updateEvent, saveImages

        }}>

            {props.children}

        </EventContext.Provider>

    )

}