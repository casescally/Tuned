import React, { useContext, useState, useEffect } from "react"

import { Link } from "react-router-dom"

import { LikedCarContext } from "../likedCar/LikedCarProvider"

import { UserContext } from "../user/UserProvider"

import "./Cars.css"
import { getUser } from "../../API/userManager"



export default ({ car }) => {


    const [carImages, setCarImages] = useState([])
    const { users } = useContext(UserContext)

    const { likedCars, addLikedCar, deleteLikedCar } = useContext(LikedCarContext)

    const carUser = users.find(u => u.id === car.userId) || {}

    const user = getUser()

    //   const currentCarsLikedCars = likedcars.filter(likedcar => likedcar.carId === car.id)

    const constructNewLikedCar = (currentCar) => {

        const alreadyLikedCarRel = likedCars.find(likedCar => likedCar.carId == currentCar.id && likedCar.user.id === user.id)

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

    let likedCarMode = Boolean

    useEffect(() => {
        const images = car.carPageCoverUrl;
        if (images) setCarImages(JSON.parse(images))
    }, [car])

    
    return (

        //car information

        <section className="carSection">

            <div className="carInfo">


            {carImages.map((image, i) => <img key={i} src={`https://localhost:5001/api/CarImages/image/get?imageName=${image}`} alt="Image of car"/>)}

                <div className="carUploader">

                    <h3>

                        <Link to={`/users/${car.userId}`}>


                            <div className="car__user">{carUser.username}</div>

                        </Link>

                    </h3>

                    <h3 className="car__name">

                        <Link to={`/cars/${car.id}`} className="carLink">

                            {car.name}

                        </Link>



                    </h3>
                       <div className="car_make">{car.make}</div>

                        <div className="car_model">{car.model}</div>
                </div>

            </div>

            <div className="likedcarInfo">

                <button className="likedcarButton" value="LikedCar" onClick={evt => {

                    evt.preventDefault()

                    constructNewLikedCar(car)

                }

                }>{likedCarMode ? "Like" : "Unlike"}</button>

            </div>

            <div className="uploaderInfo">

            </div>

        </section>

    )

}