import React, { useContext, useState, useEffect, useReducer, Component, useCallback } from "react"
import { CarContext } from "./CarProvider"
import { getUser } from "../../API/userManager"
//import { LikedCarContext } from "../likedCar/LikedCarProvider"
import { createAuthHeaders } from "../../API/userManager"
import "./Cars.css"
import ThumbnailGallery from "../thumbnail-gallery/Thumbnail-Gallery"

export default props => {

    const user = getUser();

    const { cars, addCar, saveImages, updateCar } = useContext(CarContext)

    const [car, setCar] = useState({})
    const [carImages, setCarImages] = useState([]);


    const [newCarsFiles, setNewCarsFiles] = useState([])

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

    /*const getImageSrc = (car) => {

        if (car.imageFileNames) {

            console.log(JSON.parse(car.imageFileNames)[0].split("/"))
            fetch(`https://localhost:5001/api/CarImages/image/get?imageName=${JSON.parse(car.imageFileNames)[0].split("/")}`).then(res => res.blob()).then(a => {
                setCarImage(URL.createObjectURL(a))
                console.log('a==>>', car.imageFileNames)
            })
        }
    };*/

    /*
    React relies on data flow, you should always update your "state" based on the state of the information of the app.
    server call > response from server > update the state with data from server > view is re-rendered with new data.
    */

    const constructNewCar = async () => {

        if (editMode) {
            //const newImages = carImages.filter(car => car.startsWith('blob'));
            let existingImgs = carImages.filter(car => !car.startsWith('blob'));

            console.log('newii==>>', newCarsFiles)
            console.log('existtttt==>>', existingImgs)
            if (newCarsFiles.length) {
                const filePaths = JSON.parse(await saveImages(newCarsFiles));
                console.log('filepppp==>>', filePaths)
                existingImgs = existingImgs.concat(filePaths);
            }

            let carPageCoverUrl = JSON.parse(car.carPageCoverUrl);
            if (!carPageCoverUrl.length) carPageCoverUrl = [existingImgs[0]];


            updateCar({
                ...car,
                vehicleTypeId: parseInt(car.vehicleTypeId),
                year: parseInt(car.year),
                applicationUserId: user.id,
                carPageCoverUrl: JSON.stringify(carPageCoverUrl),
                imageFileNames: JSON.stringify(existingImgs)
            })

                .then(() => {
                    props.history.push("/cars")
                })

        } else {

            let filePaths = [];
            if (newCarsFiles.length) {
                filePaths = JSON.parse(await saveImages(newCarsFiles));
            }

            addCar({
                name: car.name,
                make: car.make,
                model: car.model,
                year: car.year,
                applicationUserId: user.id,
                vehicleTypeId: car.vehicleTypeId,
                carPageCoverUrl: JSON.stringify([filePaths[0]]),
                imageFileNames: JSON.stringify(filePaths),
                carDescription: car.carDescription,
                activeCar: true

            })

                .then(() => props.history.push("/cars"))
        }
    }

    useEffect(() => {
        const images = car.imageFileNames;
        if (images) setCarImages(JSON.parse(images))
    }, [car.imageFileNames])

    /*imageFileChanged = async (event) => {

    const carImageURL = URL.createObjectURL(event.target.files[0])

    setCarImage(carImageURL)

    //console.log(event.target.files);

    console.log(filePaths);

    const newCar = {
        ...car,
        imageFileNames: filePaths,
        carPageCoverUrl: filePaths.split(',')[0]
    }

    setCar(newCar);
}*/

    const handleAddImages = files => {
        const newImgs = files.map(file => URL.createObjectURL(file));
        setCarImages([...newImgs, ...carImages]);
        setNewCarsFiles(files.concat(setNewCarsFiles));
    }

    const handleRemoveImage = index => {
        const imageToDelete = carImages[index];
        let updatedImages = [...carImages];
        updatedImages.splice(index, 1);

        if (imageToDelete.startsWith('blob')) {
            let updatedCarFiles = [...newCarsFiles];
            updatedCarFiles.splice(index, 1);
            setNewCarsFiles(updatedCarFiles);
        }
        setCarImages(updatedImages);
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
                    <select name="vehicleTypeId" required className="form-control"
                        proptype="varchar"
                        placeholder="Vehicle Type"
                        defaultValue={car.vehicleTypeId}
                        onChange={handleControlledInputChange}>
                        <option value={1}>Sports Car</option>
                        <option value={2}>Utility Vehicle</option>
                        <option value={3}>Sport Utility Vehicle</option>
                        <option value={4}>Sedan</option>
                        <option value={5}>Truck</option>
                        <option value={6}>Hatchback</option>
                        <option value={7}>Coupe</option>
                        <option value={8}>Minivan</option>
                        <option value={9}>Convertible</option>
                        <option value={10}>Compact Car</option>
                        <option value={11}>Subcompact Car</option>
                        <option value={12}>Crossover</option>
                        <option value={13}>Station Wagon</option>
                        <option value={14}>Van</option>
                        <option value={15}>Motorcycle</option>
                        <option value={16}>Supercar</option>
                    </select>


                </div>
            </fieldset>
            {/* <fieldset>
                <div className="form-group">
                    <label htmlFor="carPageCoverUrl">Car Page Cover: </label>
                    <input type="text" name="carPageCoverUrl" required className="form-control"
                        proptype="varchar"
                        placeholder="Car Page Cover"
                        defaultValue={car.carPageCoverUrlId}
                        onChange={handleControlledInputChange}
                    />
                </div>
            </fieldset> */}
            {/*<form method="post" encType="multipart/form-data" action="https://localhost:5001/api/cars" required className="form-control">
                <div>
                    <label htmlFor="imageFile">Image File</label>
                    <input name="imageFile" type="file" multiple onChange={imageFileChanged} />
                    <div className="imagePreview" id="imagePreview">
                        <img className="car_image_preview" src={carImage} />
                    <span className="image-preview__default-text">Image Preview</span>
        </div>
                </div>
            </form>*/}
            <ThumbnailGallery editMode images={carImages} handleAddImages={handleAddImages} handleRemoveImage={handleRemoveImage} />


            <fieldset>
                <div className="form-group">
                    <label htmlFor="carDescription">Description: </label>
                    <textarea name="carDescription" className="form-control"
                        value={car.carDescription}
                        onChange={handleControlledInputChange}>
                    </textarea>
                </div>
            </fieldset>
            <button type="submit"
                onClick={evt => {
                    evt.preventDefault()
                    if (editMode) {
                        constructNewCar()
                    } else {
                        constructNewCar()
                    }
                }}
                className="btn btn-primary">
                {editMode ? "Save Updates" : "Add Car"}
            </button>
        </form >
    )
}