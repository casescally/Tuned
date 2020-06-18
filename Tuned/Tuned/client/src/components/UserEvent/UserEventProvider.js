import React, { useState, useEffect } from "react"

/*

    The context is imported and used by individual components

    that need data

*/

export const UserEventContext = React.createContext()

/*

 This component establishes what data can be used.

 */

export const UserEventProvider = (props) => {

    const [userEvents, setUserEvents] = useState([])

    const getUserEvents = () => {

        return fetch("https://localhost:5001/api/UserEvent")

            .then(res => res.json())

            .then(setUserEvents)

    }



    const addUserEvent = userEvent => {

        return fetch("https://localhost:5001/api/UserEvent", {

            method: "POST",

            headers: {

                "Content-Type": "application/json"

            },

            body: JSON.stringify(userEvent)

        })

            .then(getUserEvents)

    }



    const deleteUserEvent = userEvent => {

        return fetch(`https://localhost:5001/api/UserEvent/${userEvent.id}`, {

            method: "DELETE"

        })

            .then(getUserEvents)

    }

    // const updateUserEvent = userEvent => {

    //     return fetch(`https://localhost:5001/api/UserEvents/${userEvent.id}`, {

    //         method: "PUT",

    //         headers: {

    //             "Content-Type": "application/json"

    //         },

    //         body: JSON.stringify(userEvent)

    //     })

    //         .then(getUserEvents)

    // }

    /*

        Load all likes when the component is mounted. Ensure that

        an empty array is the second argument to avoid infinite loop.

    */

    useEffect(() => {

        getUserEvents()

    }, [])

    useEffect(() => {

        // console.log("****  LIKE APPLICATION STATE CHANGED  ****")

        // console.log(likes)

    }, [userEvents])

    return (

        <UserEventContext.Provider value={{

            userEvents, addUserEvent, deleteUserEvent

        }}>

            {props.children}

        </UserEventContext.Provider>

    )

}