
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

    const saveImages = async (files) => {
        const authHeader = createAuthHeaders();
        const formData = new FormData();
        if (files) {
            Array.from(files).forEach(file => {
                formData.append(file.name, file);
            });
        }

        const response = await fetch('https://localhost:5001/api/cars/files', {
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

    const addCar = car => {

        const authHeader = createAuthHeaders();

        var form_data = new FormData();

        console.log(car);

        for (var key in car) {
            form_data.append(key, car[key]);
        }

        for (var key of form_data.entries()) {
            console.log(key[0] + ', ' + key[1]);
        }

        return fetch("https://localhost:5001/api/cars", {


            method: "POST",

            headers: {
                authHeader,
                //"Content-Type": "application/json"
            },

            body: form_data
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
        console.log('updates====>', car)
        const authHeader = createAuthHeaders();
        return fetch(`https://localhost:5001/api/cars/${car.id}`, {

            method: "PUT",

            headers: {
                authHeader,
                //"Content-Type": "application/json"

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

        //console.log("****  CAR APPLICATION STATE CHANGED  ****")
        //console.log(cars)

    }, [cars])

    return (

        <CarContext.Provider value={{

            cars, addCar, deleteCar, updateCar, saveImages

        }}>

            {props.children}

        </CarContext.Provider>

    )

}