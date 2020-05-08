import React, { useState, useEffect } from "react"

/*

    The context is imported and used by individual components

    that need data

*/

export const LikedCarContext = React.createContext()

/*

 This component establishes what data can be used.

 */

export const LikedCarProvider = (props) => {

    const [likedCars, setLikedCars] = useState([])

    const getLikedCars = () => {

        return fetch("http://localhost:5001/api/LikedCars")

            .then(res => res.json())

            .then(setLikedCars)

    }



    const addLikedCar = likedCar => {

        return fetch("http://localhost:5001/api/LikedCars", {

            method: "POST",

            headers: {

                "Content-Type": "application/json"

            },

            body: JSON.stringify(likedCar)

        })

            .then(getLikedCars)

    }



    const deleteLikedCar = likedCar => {

        return fetch(`http://localhost:5001/api/LikedCars/${likedCar.id}`, {

            method: "DELETE"

        })

            .then(getLikedCars)

    }

    const updateLikedCar = likedCar => {

        return fetch(`http://localhost:5001/api/LikedCars/${likedCar.id}`, {

            method: "PUT",

            headers: {

                "Content-Type": "application/json"

            },

            body: JSON.stringify(likedCar)

        })

            .then(getLikedCars)

    }

    /*

        Load all likes when the component is mounted. Ensure that

        an empty array is the second argument to avoid infinite loop.

    */

    useEffect(() => {

        getLikedCars()

    }, [])

    useEffect(() => {

        // console.log("****  LIKE APPLICATION STATE CHANGED  ****")

        // console.log(likes)

    }, [likedCars])

    return (

        <LikedCarContext.Provider value={{

            likedCars, addLikedCar, deleteLikedCar, updateLikedCar

        }}>

            {props.children}

        </LikedCarContext.Provider>

    )

}