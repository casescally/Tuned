import React, { useContext } from "react"
import { UserContext } from "../user/UserProvider"
import { LikedCarContext } from "../likedCar/LikedCarProvider"
import { CarContext } from "./CarProvider"
import "./Cars.css"
import { getUser } from "../../API/userManager"

export default (props) => {

    const { cars, deleteCar } = useContext(CarContext)
    const { likedCars, addLikedCar, deleteLikedCar } = useContext(LikedCarContext)
    const { users } = useContext(UserContext)

    const chosenCarId = parseInt(props.match.params.carId, 10)

    const user = getUser()
    const car = cars.find(c => c.id === chosenCarId) || {}
    const likedCar = likedCars.find(l => l.likedCarId === car.id) || {}
    const carUser = users.find(u => u.id === car.applicationUserId) || {}
    const currentUsersCars = cars.filter(c => c.userId === user.id)
    let likedCarMode = Boolean

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

    return (
        <section className="car">
            <h3 className="car__name">{car.name}</h3>
            <div className="car__make">{car.make}</div>
            <div className="car__model">{car.model}</div>
            <div className="car__year">{car.year}</div>
            

            <button className="likeButton" value="Like" onClick={evt => {

                evt.preventDefault()

                constructNewLikedCar(car)

            }

            }>{likedCarMode ? "Like" : "Unlike"}</button>

            <div className="car__user">User: {carUser.username}</div>
            
            <button onClick={
                () => {

                    deleteCar(car)
                        .then(() => {
                            props.history.push("/cars")
                        })
                }
            }>
                Delete Car

            </button>

            <button onClick={() => {
                props.history.push(`/cars/edit/${car.id}`)
            }}>Edit
            
            </button>
        </section>
    )
}