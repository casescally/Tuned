import React, { useContext, useState, useEffect } from "react"
import { CarContext } from "./CarProvider"
import { LikedCarContext } from "../likedCar/LikedCarProvider"

export default props => {
    const { likedCars } = useContext(likedCarContext)
    const { cars, addCar, updateCar } = useContext(CarContext)
    const [car, setCar] = useState({})

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
                year: car.year,
                vehicleTypeId: car.vehicleTypeId,
                carPageCoverUrl: car.carPageCoverUrl,
                likedCarId: likedCarId,
                description: car.description,
                userId: parseInt(localStorage.getItem("user"))
            })
                .then(() => props.history.push("/cars"))
        } else {
            addCar({
                name: car.name,
                make: car.make,
                model: car.model,
                year: car.year,
                vehicleTypeId: car.vehicleTypeId,
                carPageCoverUrl: car.carPageCoverUrl,
                likedcarId: likedcarId,
                description: car.description,
                customerId: parseInt(localStorage.getItem("user"))
            })
                .then(() => props.history.push("/cars"))
        }
    }


    return (
        <form className="carForm">
            <h2 className="carForm__title">{editMode ? "Update Car" : "Admit Car"}</h2>
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
                    <label htmlFor="vehicleType">Vehicle Type: </label>
                    <input type="text" name="year" required className="form-control"
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
                    <input type="text" name="year" required className="form-control"
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
                {editMode ? "Save Updates" : "-"}
            </button>
        </form>
    )
}