import React, { useContext } from "react"
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import interactionPlugin from '@fullcalendar/interaction';
import { EventContext } from "./EventProvider"
import Event from "./Event"
import "./Events.css"

export function EventList(props) {
    const { events } = useContext(EventContext)

    const handleDateClick = ({ event: { id } }) => {
        props.history.push(`/events/${id}`);
    }

    return (
        <div className="tabPanel">
            <h1>Events</h1>

            <button onClick={() => props.history.push("/events/create")}>
                Add Event
            </button>
            <FullCalendar
                plugins={[dayGridPlugin, interactionPlugin]}
                initialView="dayGridMonth"
                events={events.map(({ name, date, id }) => ({ title: name, date, id }))}
                eventClick={handleDateClick}
            />
            {/*<div className="events">
                {
                    events.map(event => {
                        return <Event key={event.id} event={event} />
                    })
                }
            </div>*/}
        </div>
    )
}