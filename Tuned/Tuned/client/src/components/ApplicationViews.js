import React from "react";
import { Route } from "react-router-dom";
import Home from "./Home";
import { CarProvider } from "./car/CarProvider"
import { EventProvider } from "./event/EventProvider"
import EventForm from "./event/EventForm"
import EventDetails from "./event/EventDetails"
import { EventList } from "./event/EventList"
import { UserProvider } from "./user/UserProvider"
import Profile from "../components/profile/Profile"
import CarForm from "./car/CarForm"
import CarDetails from "./car/CarDetails"
import { LikedCarProvider } from "./likedCar/LikedCarProvider"
import { CarList } from "./car/CarList"
import { UserEventProvider } from "./UserEvent/UserEventProvider";

export default function ApplicationViews(props) {

  return (
    <>
      <UserProvider>
        <CarProvider>
          <EventProvider>
            <LikedCarProvider>
              <UserEventProvider>
                <Route exact path="/" render={props => <Home {...props} />} />

                <Route exact path="/Cars" render={(props) => <CarList {...props} />} />

                <Route exact path="/Events" render={(props) => <EventList {...props} />} />

                <Route exact path="/cars/create" render={
                  props => <CarForm {...props} />
                } />

                <Route exact path="/cars/edit/:carId(\d+)" render={
                  props => <CarForm {...props} />
                } />


                <Route exact path="/events/create" render={
                  props => <EventForm {...props} />
                } />


                <Route exact path="/events/edit/:eventId(\d+)" render={
                  props => <EventForm {...props} />
                } />


                <Route path="/cars/:carId(\d+)" render={
                  props => <CarDetails {...props} />
                } />

                <Route path="/events/:eventId(\d+)" render={
                  props => <EventDetails {...props} />
                } />

                <Route path="/profile/:userId" render={
                  props => <Profile {...props} />
                } />

                {/* <Route path="/edit/:userId" render={
                props => <Register {...props} />
              } /> */}
              </UserEventProvider>
            </LikedCarProvider>
          </EventProvider>
        </CarProvider>
      </UserProvider>
    </>
  );
}
