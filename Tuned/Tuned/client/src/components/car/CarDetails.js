import React, { useContext, useState, useEffect } from "react"
import { UserContext } from "../user/UserProvider"
import { LikedCarContext } from "../likedCar/LikedCarProvider"
import { CarContext } from "./CarProvider"
import "./Cars.css"
import { getUser } from "../../API/userManager"
import ThumbnailGallery from '../thumbnail-gallery/Thumbnail-Gallery'

export default (props) => {

    const { cars, deleteCar } = useContext(CarContext)
    const [carImages, setCarImages] = useState([])
    const { likedCars, addLikedCar, deleteLikedCar } = useContext(LikedCarContext)
    const { users } = useContext(UserContext)
    const chosenCarId = parseInt(props.match.params.carId, 10)
    const user = getUser()
    const car = cars.find(c => c.id === chosenCarId) || {};
    const carUser = users.find(u => u.id === car.applicationUserId) || {}
    let numberOflikes = likedCars.filter(likedCar => likedCar.carId === chosenCarId).length
    let likedCarMode = Boolean

    const constructNewLikedCar = (currentCar) => {

        const alreadyLikedCarRel = likedCars.find(likedCar => likedCar.carId === currentCar.id && likedCar.user.id === user.id)

        //Don't allow duplicate liked cars
        if (alreadyLikedCarRel === undefined || null) {

            likedCarMode = false
            
            addLikedCar({

                carId: currentCar.id,

                userId: user.id

            })

        } else if (alreadyLikedCarRel !== undefined || null) {

            likedCarMode = true

            deleteLikedCar(alreadyLikedCarRel)

        }

    }

    useEffect(() => {
        const images = car.imageFileNames;
        if (images) setCarImages(JSON.parse(images))
    }, [car])

    return (
        <section className="car">
            {car.id && <div>
            <h3 className="car__name">{car.name}</h3>
            <div className="car__likes">{numberOflikes}</div>
            <div className="car__make">{car.make}</div>
            <div className="car__model">{car.model}</div>
            <div className="car__year">{car.year}</div>
            <div className="car__description">{car.carDescription}</div>
            <div><ThumbnailGallery images={carImages} /></div>

            <button className="likeButton" value="Like" onClick={evt => {

                evt.preventDefault()

                constructNewLikedCar(car)

            }

            }>{likedCarMode ? "Like" : "Unlike"}</button>

            <div className="car__user">User: {carUser.firstName + ' ' + carUser.lastName}</div>
            
            <button className="delete_button"onClick={
                () => {

                    deleteCar(car)
                        .then(() => {
                            props.history.push("/cars")
                        })
                }
            }>
                Delete Car

            </button>

            <button className="edit_button" onClick={() => {
                props.history.push(`/cars/edit/${car.id}`)
            }}>Edit
            
            </button>
            </div>}
        </section>
    )
}

