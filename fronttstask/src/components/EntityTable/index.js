import React,{useEffect, useState, useContext} from 'react';

import AddEdit from '../AddEdit';

import {MainContext} from '../../context/index';

import './index.css';


function EntityTable(props){
  const {
    getData,
    getAPI,
    deleteAPI,
  } = useContext(MainContext);

  const [editElement, setEditElement] = useState();
  const [reload, setReload] = useState(1);
  const [type, setType] = useState("add");

  useEffect(() => {
    getAPI(props.location)
  }, [props.location, reload]);

  const objectIteration = (element) => {
    let returnData = [];
    let i = 1;
    for(const property in element)
      if(element[property]){
        returnData.push(
          <div
            key={i++}
            className="etd-property"
          >
            <h4>{property}</h4>
            <h4>{element[property]}</h4>
          </div>
        );
      }

    return returnData;
  }

  const showData = (data) =>
  {
    const temp = data.map((element) => 
      <div key={element.id} className="entity-table-data">
        <button
          className="delete-button"
          onClick={() => deleteAPI(props.location,element.id,handleReload)}
        >
          DELETE
        </button>
        <button
          className="edit-button"
          onClick={() => {
            setType("edit");
            setEditElement({...element});
          }}
        >
          EDIT
        </button>
        {
          objectIteration(element) 
        }
      </div>
      );
    return temp;
  }

  const handleReload = () => {
    setReload(reload +1);
  }

  const handleChangeType = () => {
    if( type === "add" ) {
      setType("edit");
    } else {
      setType("add");
    }
  }

  
  return(
    <div className="entity-table">
      <h1 style={{margin: "5%"}}>{props.location}</h1>
      <h2 style={{margin: "5%"}}>
        Prije dodavanja sobe potrebno je imati barem jedan objekt,
        a prije dodavanja rezervacije potrebno je imati barem jednog gosta i sobu
      </h2>
        {
          getData &&
          type === "add" ?
          <AddEdit
            location={props.location}
            data={props.template}
            type={type}
            changeType={handleChangeType}
            handleReload={handleReload}
          /> :  
          <AddEdit
            location={props.location}
            data={editElement}
            type={type}
            changeType={handleChangeType}
            handleReload={handleReload}
          />
        }
        {
          getData && showData(getData)
        }
    </div>    
  )
}

export default EntityTable;