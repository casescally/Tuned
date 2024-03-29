import React from "react";
import { Link, withRouter } from "react-router-dom";
import { getUser, removeUser } from "../API/userManager";

function Header({ history }) {
  const user = getUser();

  const logout = () => {
    removeUser();
    history.push("/login");
  };

  return (
    <nav className="header">
      <img src="https://localhost:5001/api/CarImages/image/get?imageName=C:\Users\casescally\source\repos\Tuned\Tuned\Tuned\wwwroot\Upload\TunedLogo.jpeg" alt="TUNED_logo" className="TUNED_logo" />
      <ul className="nav-items">
        {user ? (
          <>
            <li className="nav-item">
              <Link to={"/profile/" + user.id}>
                Profile
              </Link>
            </li>
            <li className="nav-item">
              <Link to="/cars">
                Cars
              </Link>
            </li>
            <li className="nav-item">
              <Link to="/events">
                Events
              </Link>
            </li>
            <li className="nav-item" onClick={logout}>
              Log out
            </li>
          </>
        ) : (
            <>
              <li className="nav-item">
                <Link to="/login">Login</Link>
              </li>
              <li className="nav-item">
                <Link to="/register">Register</Link>
              </li>
            </>
          )}
      </ul>
    </nav >
  );
}

export default withRouter(Header);
