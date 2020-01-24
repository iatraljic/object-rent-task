import React,{useContext} from 'react';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';

import NavBar from './components/NavBar';
import EntityTable from './components/EntityTable';
import ShowReservations from './components/ShowReservations';
import Reservations from './components/Reservations';

import {MainContext}  from './context/index';

function App() {
  const {
    guestTemplate,
    objectTemplate,
    roomTemplate,
  } = useContext(MainContext);

  return (
    <Router>
      <div className="App">
        <NavBar/>
        <Switch>
          <Route exact path='/'>
            <EntityTable
              location='/guest'
              template={guestTemplate}
            />
          </Route>
          <Route path='/objectrent'>
            <EntityTable
              location='/objectrent'
              template={objectTemplate}
            />
          </Route>
          <Route path='/rooms'>
            <EntityTable
              location='/room'
              template={roomTemplate}
            />
          </Route>
          <Route path='/reservations'>
            <Reservations/>
          </Route>
          <Route path='/showreservations'>
            <ShowReservations/>
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
