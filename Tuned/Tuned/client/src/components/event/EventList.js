import React, { useContext } from "react"
import { EventContext } from "./EventProvider"
import Event from "./Event"
import "./Events.css"

export function EventList(props) {
    const { events } = useContext(EventContext)

    return (
        <>
            <h1>Events</h1>

            <button onClick={() => props.history.push("/events/create")}>
                Add Event
            </button>
            <div className="events">
                {
                    events.map(event => {
                        return <Event key={event.id} event={event} />
                    })
                }
            </div>
        </>
    )
}