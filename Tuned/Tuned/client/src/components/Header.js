import React from "react";
import { Link, withRouter } from "react-router-dom";
import { getUser, removeUser } from "../API/userManager";

function Header({ history }) {
  const user = getUser();


  const logout = () => {
    removeUser();
    history.push("/login");
  };

  console.log(user)

  return (
    <nav className="header">
      <ul className="nav-items">
        {user ? (
          <>
            <li className="nav-item">
              <Link to={"/users/" + user.username}>
                Hello {user.username}
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
