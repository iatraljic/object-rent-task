import React from 'react';
import {Link} from 'react-router-dom';

import './index.css';


function NavBar(props)
{
  return(
    <div className="nav-bar">
    <Link to={'/'} className="nav-link">GUESTS</Link>
    <Link to={'/objectrent'} className="nav-link" >OBJECTS</Link>
    <Link to={'/rooms'} className="nav-link" >ROOMS</Link>
    <Link to={'/reservations'} className="nav-link" >RESERVATIONS</Link>
    <Link to={'/showreservations'} className="nav-link" >SHOW RESERVATIONS</Link>
  </div>    
  )
}

export default NavBar;