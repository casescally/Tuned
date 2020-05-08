import React, { useContext } from "react"
import { CarContext } from "../car/CarProvider"
import Car from "../car/Car"
//import "../car/Cars.css"
import { UserContext } from "../user/UserProvider"
//import { LikeContext } from "../likes/LikesProvider"
//import Like from "../likes/Like"
import "./Profiles.css"

export default (props) => {

    const { cars } = useContext(CarContext)
    const { users } = useContext(UserContext)
    const chosenUserId = parseInt(props.match.params.userId, 10)
    const { likes } = useContext(LikeContext)
    const profilesArray = []
    let editProfileMode = Boolean

    if (chosenUserId !== parseInt(localStorage.getItem("currentUser"))) {
        let foundProfile = users.find(u => u.id === chosenUserId) || {}
        editProfileMode = false
        profilesArray.push(foundProfile)

    } else {
        let foundProfile = users.find(u => u.id === parseInt(localStorage.getItem("currentUser"))) || {}
        editProfileMode = true
        profilesArray.push(foundProfile)

    }

    const currentProfile = profilesArray[0]
    const currentProfileId = currentProfile.id
    const likesRelationships = likes.filter(like => like.userId === currentProfile.id)
    const currentUsersLikes = []

    {
        likesRelationships.forEach(rel => {

            // Find this relationships's matching user object
            const foundLike = cars.filter(
                (singleCar) => {
                    return rel.carId === singleCar.id
                }
            )[0]
            //if page is reloaded and no likes are found
            if (foundLike !== undefined) {
                currentUsersLikes.push(foundLike)
            }
        })
    }

    const currentUserCars = cars.filter(car => {
        return car.userId === currentProfile.id

    })

    return (

        <div className="profile">

            <section className="userProfile">

                <div className="profileBackground" style={{
                    backgroundImage: "url(" + `${currentProfile.backgroundCover}` + ")",
                    backgroundPosition: 'center',
                    // backgroundSize: 'cover',
                    backgroundRepeat: 'no-repeat',
                    objectFit: 'contain',
                    maxwidth: '100%'
                }}>

                    <span id="profileInfo">

                        <img id="profilePicture" className="profilePicture" alt={`${currentProfile.name}'s profile picture`} src={currentProfile.profilePicture}></img>

                        {<h1 className="currentProfileName">{currentProfile.name}</h1>}

                        {/* <img id="backgroundCover" className="backgroundCover" alt={`${currentProfile.name}'s background cover`} src={currentProfile.backgroundCover}></img> */}

                        {/* <button className="followButton" value="Follow">Follow</button> */}
                                    if (editProfileMode) {
                            <button className="followButton" onClick={evt => {

                                evt.preventDefault()
                                props.history.push(`edit/${currentProfileId}`)

                            }}>{editProfileMode ? "Edit" : "Follow"}

                            </button>}
                    </span>
                </div>



                <div className="mainProfileSection">
                    <article className="profileCarList">
                        <h3>Cars: {currentUserCars.length}</h3>

                        {currentUserCars.map(car => <Car key={car.id} car={car} {...props} />)}

                    </article>

                    <div className="profileSidebar">

                        <article id="profileCarCollections">


                        </article>

                        <article id="likedCars" className="profileLikesList">

                            <h3>Liked Cars</h3>

                            {currentUsersLikes.map(like => <Like key={like.id} like={like} {...props} />)}

                        </article>
                    </div>

                </div>
            </section>
        </div>
    )
}