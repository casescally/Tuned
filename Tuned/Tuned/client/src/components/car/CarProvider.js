
import React, { useState, useEffect } from "react"
import { createAuthHeaders } from "../../API/userManager"

/*

    The context is imported and used by individual components

    that need data

*/

export const CarContext = React.createContext()

/*

 This component establishes what data can be used.

 */

export const CarProvider = (props) => {

    const [cars, setCars] = useState([])

    const getCars = () => {
        const authHeader = createAuthHeaders();
        return fetch("https://localhost:5001/api/cars", {

            headers: authHeader
        })

            .then(res => res.json())

            .then(setCars)

    }

    const addCar = car => {
        const authHeader = createAuthHeaders();
        return fetch("https://localhost:5001/api/cars", {


            method: "POST",

            headers: {
                authHeader,
                "Content-Type": "application/json"

            },

            body: JSON.stringify(car)

        })

            .then(getCars)

    }

    const deleteCar = car => {
        const authHeader = createAuthHeaders();
        return fetch(`https://localhost:5001/api/cars/${car.id}`, {

            authHeader,
            method: "DELETE"

        })

            .then(getCars)

    }

    const updateCar = car => {
        const authHeader = createAuthHeaders();
        return fetch(`https://localhost:5001/api/cars/${car.id}`, {

            method: "PUT",

            headers: {
                authHeader,
                "Content-Type": "application/json"

            },

            body: JSON.stringify(car)

        })

            .then(getCars)

    }

    /*

        Load all cars when the component is mounted. Ensure that

        an empty array is the second argument to avoid infinite loop.

    */

    useEffect(() => {

        getCars()

    }, [])

    useEffect(() => {

        console.log("****  CAR APPLICATION STATE CHANGED  ****")

        console.log(cars)

    }, [cars])

    return (

        <CarContext.Provider value={{

            cars, addCar, deleteCar, updateCar

        }}>

            {props.children}

        </CarContext.Provider>

    )

}