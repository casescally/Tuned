import React, { useContext, useState, useEffect } from "react";
import { CarContext } from "./CarProvider";
import { getUser } from "../../API/userManager";
import "./Cars.css";
import ThumbnailGallery from "../thumbnail-gallery/Thumbnail-Gallery";

export default (props) => {
  const user = getUser();
  const { cars, addCar, saveImages, saveImage, updateCar } = useContext(
    CarContext
  );
  const [car, setCar] = useState({});
  const [carImages, setCarImages] = useState([]);
  const [carCoverImage, setCarCoverImage] = useState([]);
  const [newCarsFiles, setNewCarsFiles] = useState([]);
  const [newCarsCoverFile, setNewCarsCoverFile] = useState([]);
  const editMode = props.match.params.hasOwnProperty("carId");

  const handleControlledInputChange = (event) => {
    /*
            When changing a state object or array, always create a new one
            and change state instead of modifying current one
        */

    const newCar = Object.assign({}, car);
    newCar[event.target.name] = event.target.value;
    setCar(newCar);
  };

  const setDefaults = () => {
    if (editMode) {
      const carId = parseInt(props.match.params.carId);
      const selectedCar = cars.find((a) => a.id === carId) || {};
      setCar(selectedCar);
    }
  };

  useEffect(() => {
    setDefaults();
  }, [cars]);

  /*
    React relies on data flow, you should always update your "state" based on the state of the information of the app.
    server call > response from server > update the state with data from server > view is re-rendered with new data.
    */

  const constructNewCar = async () => {
    if (editMode) {
      //Filter the car images that are not blob data
      let existingImgs = carImages.filter((car) => !car.startsWith("blob"));
      let existingCoverImg = carCoverImage.filter(
        (coverImg) => !coverImg.startsWith("blob")
      );
      //let existingCoverImg = carPageCoverUrl
      if (newCarsFiles.length) {
        const filePaths = JSON.parse(await saveImages(newCarsFiles));
        existingImgs = existingImgs.concat(filePaths);
      }

      if (newCarsCoverFile.length) {
        const carCoverImage = JSON.parse(await saveImages(newCarsCoverFile));
        existingCoverImg = carCoverImage;
      }

      //if (!carPageCoverUrl.length) carPageCoverUrl = [existingImgs[0]];

      //   if (carCoverImage.length === 0) {

      //     updateCarsCoverImage(existingImgs[0]);

      //   }

      updateCar({
        ...car,
        vehicleTypeId: parseInt(car.vehicleTypeId),
        year: parseInt(car.year),
        applicationUserId: user.id,
        carPageCoverUrl: JSON.stringify(existingCoverImg),
        imageFileNames: JSON.stringify(existingImgs),
      }).then(() => {
        props.history.push("/cars");
      });
    } else {
      // let existingCoverImg = [carCoverImage].filter((car) => !car.startsWith("blob"));

      // if (carCoverImage.length) {
      //   const coverFilePath = JSON.parse(await saveImages(carCoverImage));
      //   existingCoverImg = existingCoverImg.concat(coverFilePath);
      // }
      let filePaths = [];
      let coverIMG = [
        "https://localhost:5001/api/CarImages/image/get?imageName=C:Userscasescallysource\reposTunedTunedTunedwwwrootUploadTunedLogo.jpeg",
      ];
      if (newCarsFiles.length) {
        console.log("before uploadd upp===>>>", newCarsFiles);
        const uploadedCarImages = await saveImages(newCarsFiles);
        filePaths = JSON.parse(uploadedCarImages);
        coverIMG = filePaths[0];
        console.log("upp==>>>>>", JSON.stringify(filePaths));
      }

      //   let coverImgPath = [];
      //   if (!carCoverImage.length) {
      //     coverImgPath = filePaths[0]
      //     console.log('COVER=====>>>>', coverImgPath)
      //   }
      //   let carCover = [filePaths[0]]
      //   if (carCoverImage.length) {
      //   carCover = JSON.parse(await saveImages(carCoverImage));
      //      console.log('COVER=====>>>>', carCover)
      //   }

      addCar({
        name: car.name,
        make: car.make,
        model: car.model,
        year: car.year,
        applicationUserId: user.id,
        vehicleTypeId: car.vehicleTypeId,
        carPageCoverUrl: JSON.stringify([coverIMG]),
        imageFileNames: JSON.stringify(filePaths),
        carDescription: car.carDescription,
        activeCar: true,
      }).then(() => props.history.push("/cars"));
    }
  };

  useEffect(() => {
    const images = car.imageFileNames;
    if (images) setCarImages(JSON.parse(images));
  }, [car.imageFileNames]);

  const updateCarsCoverImage = (file) => {
    // let coverImageFile = new Blob([file], {
    //   type: "image/jpeg",
    // });
    // const newCoverImg = URL.createObjectURL(coverImageFile);

    // debugger
    // setCarCoverImage([...newCoverImg])
    // setNewCarsCoverFile([newCarsCoverFile]);
    console.log('upppdatedddd===>>>>', file)
  };

  const handleAddImages = (files) => {
    //console.log("heyyup==>>>", files);
    const newImgs = files.map((file) => URL.createObjectURL(file));
    setCarImages([...newImgs, ...carImages]);
    setNewCarsFiles(files.concat(newCarsFiles));
  };

  const handleRemoveImage = (index) => {
    const imageToDelete = carImages[index];
    let updatedImages = [...carImages];
    updatedImages.splice(index, 1);

    if (imageToDelete.startsWith("blob")) {
      let updatedCarFiles = [...newCarsFiles];
      updatedCarFiles.splice(index, 1);
      setNewCarsFiles(updatedCarFiles);
    }
    setCarImages(updatedImages);
  };

  console.log(carImages);
  return (
    <form className="carForm">
      <h2 className="carForm__title">{editMode ? "Update Car" : "Add Car"}</h2>
      <fieldset>
        <div className="form-group">
          <label htmlFor="name">Car name: </label>
          <input
            type="text"
            name="name"
            required
            autoFocus
            className="form-control"
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
          <input
            type="text"
            name="make"
            required
            className="form-control"
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
          <input
            type="text"
            name="model"
            required
            className="form-control"
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
          <input
            type="text"
            name="year"
            required
            className="form-control"
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
          <select
            name="vehicleTypeId"
            required
            className="form-control"
            proptype="varchar"
            placeholder="Vehicle Type"
            defaultValue={car.vehicleTypeId}
            onChange={handleControlledInputChange}
          >
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
      <div className="divider div-transparent"></div>
      <ThumbnailGallery
        editMode
        images={carImages}
        handleAddImages={handleAddImages}
        handleRemoveImage={handleRemoveImage}
        setCarImages={setCarImages}
        updateCarsCoverImage={updateCarsCoverImage}
      />
      <fieldset>
        <div className="form-group" id="carDescription">
          <label htmlFor="carDescription">Description: </label>
          <textarea
            name="carDescription"
            className="form-control"
            id="carDescriptionForm"
            value={car.carDescription}
            onChange={handleControlledInputChange}
          ></textarea>
        </div>
      </fieldset>
      <button
        type="submit"
        id="addCarButton"
        onClick={(evt) => {
          evt.preventDefault();
          //console.log(carCoverImage)
          constructNewCar();
        }}
        className="btn btn-primary"
      >
        {editMode ? "Save Updates" : "Add Car"}
      </button>
    </form>
  );
};
