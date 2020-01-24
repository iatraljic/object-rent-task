import React, { useEffect, useState, useContext } from 'react';
import Select from 'react-select';
import axios from 'axios';

import {MainContext} from '../../context/index';

import './index.css';

function Reservations() {
  const {
    guestsReservationsAdd,
    getGuestReservationsAdd,
    roomsReservationsAdd,
    getRoomsReservationsAdd,
  } = useContext(MainContext);

  const [guestsValue, setGuestsValue] = useState(0);
  const [roomsValue, setRoomsValue] = useState(0);
  const [odDatumaValue, setOdDatumaValue] = useState(0);
  const [doDatumaValue, setDoDatumaValue] = useState(0);


  useEffect(() => {
    getGuestReservationsAdd();
    getRoomsReservationsAdd();
  }, []);

  const handleChangeGuest = selectedOption =>
    setGuestsValue(selectedOption.value);

  const handleChangeRoom = selectedOption =>
    setRoomsValue(selectedOption.value);

  const handleChangeOdDatuma = e => setOdDatumaValue(e.target.value);

  const handleChangeDoDatuma = e => setDoDatumaValue(e.target.value);

  const handleSubmit = () => {
    const postValue =     {
      RoomID: roomsValue,
      GuestID: guestsValue,
      fromDate: odDatumaValue,
      toDate: doDatumaValue,
    };

    console.log(postValue);

    axios.post('/reservation', postValue)
      .then(res => {
        console.log(res);        
      })
      .catch(err => console.log(err));


      setGuestsValue(0);
      setRoomsValue(0);
      setOdDatumaValue(0);
      setDoDatumaValue(0);
  };

  return (
    <div className="reservations">
      <h1>Reservations</h1>
      <table>
        <tbody>
          <tr>
            <td>Guest</td>
            <td style={{ width: '300px' }}>
              <Select
                options={guestsReservationsAdd}
                onChange={handleChangeGuest}
              />
            </td>
            <td>(Potrebno je imati barem jednog gosta u bazi!)</td>
          </tr>
          <tr>
            <td>Room</td>
            <td>
              <Select
                options={roomsReservationsAdd}
                onChange={handleChangeRoom}
              />
            </td>
            <td>(Potrebno je imati barem jednu sobu u bazi!)</td>
          </tr>
          <tr>
            <td>Od Datuma</td>
            <td>
              <input
                name='OdDatuma'
                onChange={e => handleChangeOdDatuma(e)}
                placeholder="pr. M-D-G"
              />
            </td>
          </tr>
          <tr>
            <td>Do Datuma</td>
            <td>
              <input
                name='DoDatuma'
                onChange={e => handleChangeDoDatuma(e)}
                placeholder="pr. M-D-G"
              />
            </td>
          </tr>
        </tbody>
      </table>
      <button 
        className="button"
        onClick={handleSubmit}
      >
        SUBMIT
      </button>
    </div>
  );
}

export default Reservations;




