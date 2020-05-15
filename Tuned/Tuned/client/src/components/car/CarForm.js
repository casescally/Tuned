import React, { useContext, useState, useEffect, useReducer } from "react"
import { CarContext } from "./CarProvider"
//import { LikedCarContext } from "../likedCar/LikedCarProvider"

export default props => {
    // const { likedCars } = useContext(LikedCarContext)
    const { cars, addCar, updateCar } = useContext(CarContext)
    const [car, setCar] = useState({
        "url": 1,
        "applicationUserId": JSON.parse(localStorage.getItem("user")).id,
        "activeCar": true,
        "vehicleTypeId": 3,
        "year": 1998,
        "carDescription": "something"
    })

    const editMode = props.match.params.hasOwnProperty("carId")

    const handleControlledInputChange = (event) => {
        /*
            When changing a state object or array, always create a new one
            and change state instead of modifying current one
        */
        const newCar = Object.assign({}, car)
        newCar[event.target.name] = event.target.value
        setCar(newCar)
    }

    const setDefaults = () => {
        if (editMode) {
            const carId = parseInt(props.match.params.carId)
            const selectedCar = cars.find(a => a.id === carId) || {}
            setCar(selectedCar)
        }
    }

    useEffect(() => {
        setDefaults()
    }, [cars])

    const constructNewCar = () => {

        if (editMode) {
            updateCar({
                id: car.id,
                name: car.name,
                make: car.make,
                model: car.model,
                year: parseInt(car.year),
                vehicleTypeId: parseInt(car.vehicleTypeId),
                carPageCoverUrl: car.carPageCoverUrl,
                carDescription: car.description,
                applicationUserId: localStorage.getItem("user").id
            })

                .then(() => props.history.push("/cars"))
        } else {
            addCar({
                "name": car.name,
                "make": car.make,
                "model": car.model,
                //year: parseInt(car.year),
                // vehicleTypeId: parseInt(car.vehicleTypeId),
                "carPageCoverUrl": car.carPageCoverUrl,
                //carDescription: car.description,

            })
                .then(console.log(car))
                .then(() => props.history.push("/cars"))
        }
    }


    return (
        <form className="carForm">
            <h2 className="carForm__title">{editMode ? "Update Car" : "Add Car"}</h2>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="name">Car name: </label>
                    <input type="text" name="name" required autoFocus className="form-control"
                        proptype="varchar"
                        placeholder="Car name"
                        defaultValue={car.name}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="make">Car make: </label>
                    <input type="text" name="make" required className="form-control"
                        proptype="varchar"
                        placeholder="Car make"
                        defaultValue={car.make}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="model">Car model: </label>
                    <input type="text" name="model" required className="form-control"
                        proptype="varchar"
                        placeholder="Car model"
                        defaultValue={car.model}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="year">Car year: </label>
                    <input type="text" name="year" required className="form-control"
                        proptype="varchar"
                        placeholder="Car year"
                        defaultValue={car.year}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="vehicleTypeId">Vehicle Type: </label>
                    <input type="text" name="vehicleTypeId" required className="form-control"
                        proptype="varchar"
                        placeholder="Vehicle Type"
                        defaultValue={car.vehicleTypeId}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="carPageCoverUrl">Car Page Cover: </label>
                    <input type="text" name="carPageCoverUrl" required className="form-control"
                        proptype="varchar"
                        placeholder="Car Page Cover"
                        defaultValue={car.carPageCoverUrlId}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="description">Description: </label>
                    <textarea type="text" name="description" className="form-control"
                        proptype="varchar"
                        value={car.description}
                        onChange={handleControlledInputChange}>
                    </textarea>
                </div>
            </fieldset>
            <button type="submit"
                onClick={evt => {
                    evt.preventDefault()
                    constructNewCar()
                }}
                className="btn btn-primary">
                {editMode ? "Save Updates" : "Add Car"}
            </button>
        </form>
    )
}