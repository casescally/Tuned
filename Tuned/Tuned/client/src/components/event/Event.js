import React, { useContext, useState, useEffect } from "react"
import { Link } from "react-router-dom"
import { UserContext } from "../user/UserProvider"
import "./Events.css"
import { getUser } from "../../API/userManager"

export default ({ event }) => {

    const { users } = useContext(UserContext)
    const eventUser = users.find(u => u.id === event.userId) || {}
    const [eventImages, setEventImages] = useState([]);

    useEffect(() => {
        const images = event.imagePath;
        if (images) setEventImages(JSON.parse(images));}, [event]);
    return (

        <section className="eventSection">

            <div className="eventInfo">
            {eventImages.map((image, i) => (
        <img
          key={i}
          src={`https://localhost:5001/api/EventImages/image/get?imageName=${image}`}
          className="event_image"
          alt="Event"
        />
      ))}
                <h3 className="event__name">

                    <Link to={`/events/${event.id}`} className="eventLink">

                        {event.name + '    '}

                    </Link>
                    {event.date.slice(0, 10)}
                </h3>
                <img className="coverImage" src={event.eventCoverUrl}></img>

                <div className="eventUploader">

                    <h3>

                        <Link to={`/users/${event.applicationUserId}`}>


                            <div className="event__user">{eventUser.username}</div>

                        </Link>

                    </h3>

                </div>
            </div>

            <div className="likedeventInfo">

            </div>

            <div className="creatorInfo">

            </div>
            <div class="divider div-transparent"></div>
        </section>

    )

}