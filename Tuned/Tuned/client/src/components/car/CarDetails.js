import React, { useContext, useState, useEffect } from "react";
import { UserContext } from "../user/UserProvider";
import { LikedCarContext } from "../likedCar/LikedCarProvider";
import { CarContext } from "./CarProvider";
import "./Cars.css";
import { getUser } from "../../API/userManager";
import ThumbnailGallery from "../thumbnail-gallery/Thumbnail-Gallery";
import SimpleReactLightBox from "simple-react-lightbox";
import { SRLWrapper } from "simple-react-lightbox";

export default (props) => {
    const { cars, deleteCar } = useContext(CarContext);
    const [carImages, setCarImages] = useState([]);
    const { likedCars, addLikedCar, deleteLikedCar } = useContext(
        LikedCarContext
    );
    const { users } = useContext(UserContext);
    const chosenCarId = parseInt(props.match.params.carId, 10);
    const user = getUser();
    const car = cars.find((c) => c.id === chosenCarId) || {};
    const carUser = users.find((u) => u.id === car.applicationUserId) || {};
    let numberOflikes = likedCars.filter(
        (likedCar) => likedCar.carId === chosenCarId
    ).length;
    let likedCarMode = Boolean;
    let detailMode = props.match.params.hasOwnProperty("carId")
    // const [isOpened, setIsOpened] = useState(true);

    // function toggle() {
    //   setIsOpened(wasOpened => !wasOpened);
    // }


    const constructNewLikedCar = (currentCar) => {
        const alreadyLikedCarRel = likedCars.find(
            (likedCar) =>
                likedCar.carId === currentCar.id && likedCar.user.id === user.id
        );

        //Don't allow duplicate liked cars
        if (alreadyLikedCarRel === undefined || null) {
            likedCarMode = false;

            addLikedCar({
                carId: currentCar.id,

                userId: user.id,
            });
        } else if (alreadyLikedCarRel !== undefined || null) {
            likedCarMode = true;

            deleteLikedCar(alreadyLikedCarRel);
        }
    };

    useEffect(() => {

        const images = car.imageFileNames;
        if (images) setCarImages(JSON.parse(images));

    }, [car]);

    return (
        <section className="car top-space">
            {car.id && (
                <div>
                    <h3 className="car__name">{car.name}</h3>
                    <div className="car__likes">Likes: {numberOflikes}</div>
                    <div className="car__make">Make: {car.make}</div>
                    <div className="car__model">Model: {car.model}</div>
                    <div className="car__year">Year: {car.year}</div>
                    <div className="car__description">Description: {car.carDescription}</div>
                    {/*<button className="showHideGallery" onClick={toggle}>Gallery</button>*/}
                    {detailMode !== true && (<ThumbnailGallery images={carImages} />)}
                    {detailMode && (<SimpleReactLightBox>
                        <SRLWrapper>
                            {carImages.map((image, i) => {
                                return (
                                    <a key={i} href={`https://localhost:5001/api/CarImages/image/get?imageName=${image}`} data-attribute="SRL">
                                        <img
                                            src={`https://localhost:5001/api/CarImages/image/get?imageName=${image}`}
                                            className="car_image"
                                            alt="Car"
                                        />
                                    </a>
                                );
                            })}
                        </SRLWrapper>
                    </SimpleReactLightBox>)}
                    {/* <Modal show={show} onHide={handleClose}>
                        here is the modal
          </Modal> */}
                    <button
                        className="likeButton"
                        value="Like"
                        onClick={(evt) => {
                            evt.preventDefault();

                            constructNewLikedCar(car);
                        }}
                    >
                        {likedCarMode ? "Like" : "Unlike"}
                    </button>

                    <div className="car__user">
                        User: {carUser.firstName + " " + carUser.lastName}
                    </div>

                    <button
                        className="delete_button"
                        onClick={() => {
                            deleteCar(car).then(() => {
                                props.history.push("/cars");
                            });
                        }}
                    >
                        Delete Car
          </button>

                    <button
                        className="edit_button"
                        onClick={() => {
                            props.history.push(`/cars/edit/${car.id}`);
                        }}
                    >
                        Edit
          </button>
                </div>
            )}
        </section>
    );
};
