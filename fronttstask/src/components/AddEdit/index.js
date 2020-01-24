import React,{useState, useEffect, useContext} from 'react';
import Select from 'react-select';

import {MainContext} from '../../context/index';
import axios from 'axios';

import './index.css';

function AddEdit(props){
  const {
    postAPI,
    putAPI,
  } = useContext(MainContext)
  const [startAction, setStartAction] = useState(false);
  const [actionElement, setActionElement] = useState(null);
  const [objName, setObjName] = useState([]);

  useEffect(() => {
    setActionElement(props.data);
    getObjectName();
  },[props.data]);

  const getObjectName = async () => {
    const res = await axios.get('/objectrent');

    setObjName(res.data);
  }

  const handleChangeObj = (selectedOption) => {
    setActionElement(
      {
        ...actionElement,
        "ObjectRentID": selectedOption.value,
      });
  }

  const createForm = (dataObject) => {
    const formElements = [];
    let i=1;

    for(const property in dataObject){
      if(property !== 'id' && property!== 'ObjectRentID' && dataObject[property] !== null){
        formElements.push(
          <tr key={i++}>
            <td>
              {property}
            </td>
            <td>
              <input
                placeholder={props.type === 'add' ? "" : dataObject[property]}
                name={property}
                onChange={(e) => handleChange(e)}
              /> 
            </td>       
          </tr>
        );
      } else if(property === 'ObjectRentID') {
        const arr = objName.map(el => {
          return {
            value: el.id,
            label: el.name
          }
        });
        formElements.push(
          <tr key={i++}>
            <td>{property}:</td>
            <td>
              <Select
                options={arr}
                onChange={handleChangeObj}
              />
            </td>
            <td>(Potrebno je imati barem jedan objekt u bazi!)</td>
          </tr>
        );
      }
    }

    return formElements;
  }

  const handleChange = (e) => {
    for(const prop in actionElement) {
      if(e.target.name===prop) {
        setActionElement({...actionElement, [prop]: e.target.value})
      }
    }
  }

  const onSubmit = async () => {
    postAPI(props.location, actionElement, props.handleReload);

    setStartAction(false);
  }

  const onEdit = () => {
    putAPI(props.location, actionElement, props.handleReload);

    setStartAction(false);
    props.changeType();
  }

  return(
    <div className="add-new">
      {
        !startAction && props.type ==='add' ? 
        <button
          className="button"
          onClick={() => setStartAction(true)}
        >
          ADD NEW
        </button> :
        <div>
          <table>
            <tbody>
              {
                props.type === 'add' ?
                props.data && createForm(props.data) :
                createForm(props.data)
              }
            </tbody>
          </table>
          {
            props.type === 'add' ?
            <button
              className="button"
              onClick={onSubmit}
            >
              SUBMIT
            </button> :
            <button
              className="button"
              onClick={onEdit}
            >
              FINISH EDITING
            </button>
          }  
        </div>
      }
    </div>
  )
}

export default AddEdit;