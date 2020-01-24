import React, {useEffect, useContext} from 'react';

import {MainContext} from '../../context/index';

import './index.css'

function ShowReservations(){
  const {reservationsShowData, getReservationsShow} = useContext(MainContext);

  useEffect(() => {
    getReservationsShow();
  }, []);

  const showReservationsData = () => {
    const reservations = reservationsShowData.map((el, keyI) =>
      <div className="reservation-info" key={keyI++}>
        <h3>IME: {el.fullName}</h3>
        <h3>EMAIL: {el.email}</h3>
        <h3>OD: {el.fromDate}</h3>
        <h3>DO: {el.toDate}</h3>
        <h3>ROOM NAME: {el.roomName}</h3>
        <h3>OBJECT NAME: {el.objectName}</h3>
      </div>
    );

    return reservations;
  }


  return(
    <div className="show-reservations">
      <h1 style={{margin: "5%"}}>Show Reservations</h1>
      {
        reservationsShowData !== null &&
        showReservationsData()
      }
    </div>
  )
}

export default ShowReservations;