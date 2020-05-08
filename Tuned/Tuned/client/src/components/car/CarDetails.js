import React, { useContext, useState } from "react"

import { Link } from "react-router-dom"

import { LikeContext } from "../likedcars/LikedCarsProvider"

import { UserContext } from "../user/UserProvider"

import "./Cars.css"


export default ({ car }) => {

    const { users } = useContext(UserContext)

    const { likedcars, addLike, deleteLike } = useContext(LikeContext)

    const user = users.find(u => u.id === car.userId) || {}

    const currentCarsLikedCars = likedcars.filter(like => like.carId === car.id)

    const constructNewLike = (currentCar) => {

        const alreadyLikedCar = likedcars.find(like => like.carId === currentCar.id && like.userId === parseInt(localStorage.getItem("currentUser")))

        const user = users.find(u => u.id === car.userId) || {}

        //Don't allow duplicate liked cars

        if (alreadyLikedCar === undefined) {

            likedCarMode = false

            addLike({

                carId: currentCar.id,

                userId: parseInt(localStorage.getItem("currentUser"))

            })

        } if (alreadyLikedCar !== undefined) {

            likedCarMode = true

            deleteLike(likedcars.find(like => like.carId === currentCar.id && like.userId === parseInt(localStorage.getItem("currentUser"))))

        }

    }

    let likedCarMode = Boolean

    return (



        //car information

        <section className="Carsection">

            <div className="carInfo">



                <img className="coverImage" src={car.carPageCoverUrl}></img>


                <div className="carUploader">



                    <h3>

                        <Link to={`/users/${car.userId}`}>



                            <div className="car__user">{user.username}</div>

                        </Link>

                    </h3>

                    {/* {console.log(currentCarsLikedCars)} */}

                    <h3 className="car__name">

                        <Link to={`/cars/${car.id}`} className="carLink">

                            {car.name}

                        </Link>



                    </h3>



                </div>

            </div>

            <div className="likeInfo">



                LikedCars: {currentCarsLikedCars.length}

                <button className="likeButton" value="Like" onClick={evt => {

                    evt.preventDefault()



                    constructNewLike(car)

                }

                }>{likedCarMode ? "Like" : "Unlike"}</button>

            </div>

            <div className="uploaderInfo">

            </div>

        </section>

    )

}