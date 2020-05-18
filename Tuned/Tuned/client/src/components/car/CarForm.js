import React, { useContext, useState, useEffect, useReducer } from "react"
import { CarContext } from "./CarProvider"
import { getUser } from "../../API/userManager"
//import { LikedCarContext } from "../likedCar/LikedCarProvider"
import { createAuthHeaders } from "../../API/userManager"
import "./Cars.css"

export default props => {

    const user = getUser();

    // const { likedCars } = useContext(LikedCarContext)

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

    const imageFileChanged = (event) => {
        console.log(event.target.files);
        const newCar = Object.assign({}, car)
        newCar['imageFile'] = event.target.files[0];
        setCar(newCar);
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

                name: car.name,
                make: car.make,
                model: car.model,
                year: parseInt(car.year),
                applicationUserId: user.id,
                vehicleTypeId: parseInt(car.vehicleTypeId),
                carPageCoverUrl: car.carPageCoverUrl,
                carDescription: car.description,
                activeCar: true,
                imageFile: car.imageFile
            })
                //console.log(car)

                .then(() => props.history.push("/cars"))
        }
    }

    // async function sendImage(event) {
    //     event.preventDefault();
    //     console.log(this.state.file);
    //     await this.addImage(this.state.file);
    //     console.log('it works');
    // };
    // async function addImage(image) {
    //     const authHeader = createAuthHeaders();
    //     await fetch('https://localhost:44385/api/cars',

    //         {

    //             method: 'POST',
    //             mode: 'cors',
    //             headers: {
    //                 //'Accept': 'application/json',
    //                 //'Authorization': 'Bearer ' + sessionStorage.tokenKey
    //                 headers: authHeader
    //             },
    //             body: this.state.file
    //         }
    //     )
    // }

    // async function handleImageChange(e) {
    //     e.preventDefault();
    //     let form = new FormData();
    //     for (var index = 0; index < e.target.files.length; index++) {
    //         var element = e.target.files[index];
    //         form.append('image', element);
    //     }
    //     form.append('fileName', "Img");
    //     this.setState({ file: form });
    // };

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
            <form method="post" encType="multipart/form-data" action="https://localhost:5001/api/cars" required className="form-control">

                <div>
                    <label htmlFor="imageFile">Image File</label>
                    <input name="imageFile" type="file" onChange={imageFileChanged} />
                    <div className="imagePreview" id="imagePreview">
                        <img src="" alt="Image Preview" className="image-preview__image"></img>
                        <span class="image-preview__default-text">Image Preview</span>
                    </div>
                </div>
                <div>
                    <input type="submit" value="Submit" />
                </div>
            </form>
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