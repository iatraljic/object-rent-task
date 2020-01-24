import React, {
  createContext,
  useState
} from 'react';
import axios from 'axios';

export const MainContext = createContext();

function AppContext(props) {
  const [reservationsShowData, setReservationsShowData] = useState([]);
  const [guestsReservationsAdd, setGuestsReservationsAdd] = useState([]);
  const [roomsReservationsAdd, setRoomsReservationsAdd] = useState([]);
  const [getData, setGetData] = useState([]);

  const [guestTemplate] = useState(
      {
        fullName: "",
        Adress: "",
        City: "",
        Card: "",
        Email: "",
        Password: "",
      }
    );

  const [objectTemplate] = useState(
      {
        Name: "",
        Category: "",
        Adress: "",
        City: "",
      }
    );

  const [roomTemplate] = useState(
      {
        RoomName: "",
        BedNumber: "",
        PersonNumber: "",
        Area: "",
        Dodatno: "",
        ObjectRentID: "",
      }
    );

  const [reservationTemplate] = useState(
      {
        fromDate: "",
        toDate: "",
        GuestID: "",
        RoomID: "",
      }
    );

  /****************GET API START****************/
  const getAPI = async (location) => {

    const res = await axios.get(location) 
  
    setGetData(res.data);
  }
  /****************GET API END****************/

  /****************DELETE API START****************/
  const deleteAPI = async (location, id, handleReload) => {

    axios.delete(location + '/' + id)
    .then(res => {
      console.log(res);
      handleReload();
    })
    .catch(err => console.log(err));

  }
  /****************DELETE API END****************/

  /****************POST API START****************/
  const postAPI = async (location, el, handleReload) => {

    axios.post(location, el)
    .then(res => {
      console.log(res);
      handleReload();
    })
    .catch(err => console.log(err));

  }
  /****************POST API END****************/

  /****************EDIT API START****************/
  const putAPI = async (location, el, handleReload) => {

    axios.put(location + '/' + el.id, el)
    .then((res) => {
      console.log(res)
      handleReload();
    })
    .catch((err) => console.log(err))

  }
  /****************EDIT API END****************/

  /****************DATA RESETVATIONS SHOW START****************/
  const getReservationsShow = async () => {
    const res = await axios.get('/reservation/join');

    setReservationsShowData(res.data);
  }
  /****************DATA RESETVATIONS SHOW END****************/

  /****************DATA RESETVATIONS START****************/
  const getGuestReservationsAdd = async () => {
    const res = await axios.get('/guest');

    const arr = res.data.map(el => {
      return {
        value: el.id,
        label: el.fullName
      }
    });
    setGuestsReservationsAdd(arr);
  }


  const getRoomsReservationsAdd = async () => {
    const res = await axios.get('/room/roomObjectName');

    const arr = res.data.map(el => {
      return {
        value: el.id,
        label: `${el.roomName} (${el.objectName})`
      };
    });
    setRoomsReservationsAdd(arr);
  }
  /****************DATA RESETVATIONS SHOW END****************/

  return (
    <MainContext.Provider
      value = {{
        getData,
        getAPI,
        deleteAPI,
        postAPI,
        putAPI,
        guestTemplate,
        objectTemplate,
        roomTemplate,
        reservationTemplate,
        getReservationsShow,
        reservationsShowData,
        getGuestReservationsAdd,
        guestsReservationsAdd,
        getRoomsReservationsAdd,
        roomsReservationsAdd,
      }}
    >
      {props.children}
    </MainContext.Provider>
  );
};

export default AppContext;