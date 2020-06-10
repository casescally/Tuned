import React, { useContext, useState, useEffect, useReducer } from "react"
import { CarContext } from "./CarProvider"
import { getUser } from "../../API/userManager"
//import { LikedCarContext } from "../likedCar/LikedCarProvider"
import { createAuthHeaders } from "../../API/userManager"
import "./Cars.css"

export default props => {
 
    const user = getUser();

    // const { likedCars } = useContext(LikedCarContext)

    const { cars, addCar, saveImages, updateCar } = useContext(CarContext)

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

    const imageFileChanged = async (event) => {
        console.log(event.target.files);
        const filePaths = await saveImages(event.target.files);
        //car['imageFileNames'] = filePaths;
        //for loop  filePaths.split(','); => arrray of base64 images.
        console.log(filePaths);
        //setCar(car);
        //setCar({
        //    imageFileNames: filePaths
        // })

        const newCar = Object.assign({

            imageFileNames: filePaths,
            carPageCoverUrl: filePaths.split(',')[0]
        }, car)

        //newCar['carPageCoverUrl'] = filePaths[0];
        //console.log(event.target)
        console.log(newCar)
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

    const getImageSrc = () => {

        if (car.imageFileNames) {
            console.log(JSON.parse(car.imageFileNames)[0].split("/"))
         return fetch(`https://localhost:5001/api/CarImages/image/get?imageName=${JSON.parse(car.imageFileNames)[0].split("/")}`)  //car.imageFilePaths[index]
        }

        };



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
                applicationUserId: user.id,

            })

                .then(() => props.history.push("/cars"))

        } else {

            addCar({

                name: car.name,
                make: car.make,
                model: car.model,
                year: car.year,
                applicationUserId: user.id,
                vehicleTypeId: parseInt(car.vehicleTypeId),
                carPageCoverUrl: car.carPageCoverUrl,
                imageFileNames: car.imageFileNames,
                carDescription: car.description,
                activeCar: true

            })

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
                    <input name="imageFile" type="file" multiple onChange={imageFileChanged} />
                    <div className="imagePreview" id="imagePreview">
                        <img src={getImageSrc()}></img>
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