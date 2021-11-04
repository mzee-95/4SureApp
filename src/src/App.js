import './App.css';
import { observer } from 'mobx-react';
import userStore from './stores/userStore';
import SearchForm from './SearchForm';
import React, { useState } from 'react';
import PrimeCard from './compnents/PrimeCard';
import UserActivity from './stores/UserActivity';
import UserActivities from './compnents/UserActivities';
import ConnectionStore from './stores/ConnectionStore';
import { Dialog } from "primereact/dialog";
import "./styles/styles.css";
import "./styles/grid.css";
import Navbar from './Navbar';
import img from "./assets/download.jpeg";


class App extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      isloading: false
    };
  }

  async componentDidMount() {
    console.log(userStore.users.length);
  }


  render() {
    console.log(userStore.users);
    if (ConnectionStore.isLoading) {
      return (<div id="loading"></div>)
    }
    else if (ConnectionStore.isActivitySearchOffline) {
      if (UserActivity.showModal) {
        return (
          <div >
            <div class="wrapper-four-col">
              <Navbar />
              <PrimeCard />
              <Dialog
                className="text"
                header="Users Activities"
                closable="true"
                style={{ width: "80vw" }}
                visible={UserActivity.showModal}
                onHide={(e) => UserActivity.showModal = false}
                position="top"
                modal="true"
              >
                <UserActivities />
              </Dialog>
            </div>
          </div>
        )
      }
      else {
        return (
          <div>
            <div className="app">
              <Navbar />
              <div>
              </div>
              <div className="container">
                <div className="text">
                  Unfortunately, we are unable to fetch the <u>Activity Data</u> at the moment... please try again later :)
                </div>
                <SearchForm></SearchForm>
              </div>
              <br />
              <br />
              <div className="bg">
                <img src={img} alt="cannot display" />
              </div>
            </div>
          </div>
        );
      }
    }
    else if (ConnectionStore.isUserSearchOffline) {
      if (userStore.users != null && userStore.users.length > 0) {
        return (
          <div>
            <div>
              <Navbar />
              <p className="text">Search Results</p>
              <SearchForm></SearchForm>
              <p> You seem to be offline. Here are your previous searches</p>
              <div class="wrapper-four-col">
                <PrimeCard />
              </div>
            </div>
          </div>
        )
      }
      else {
        return (
          <div>
            <div className="app">
              <Navbar />
              <div>
              </div>
              <div className="container">
                <div className="text" >
                  Unfortunately, we are unable to fetch the <u>User Data</u> at the moment... please try again later :)
                </div>
                <SearchForm></SearchForm>
              </div>
              <br />
              <br />
              <div className="bg">
                <img src={img} alt="cannot display" />
              </div>
            </div>
          </div>
        );
      }
    }
    else if (UserActivity.showModal) {
      return (
        <div >
          <div class="wrapper-four-col">
            <Navbar />
            <PrimeCard />
            <Dialog className="text"
              header="Users Activities"
              closable="true"
              style={{ width: "80vw" }}
              visible={UserActivity.showModal}
              onHide={(e) => UserActivity.showModal = false}
              position="top"
              modal="true"
            >
              <UserActivities />
            </Dialog>
          </div>
        </div>
      )
    }
    else if (userStore.users != null && userStore.users.length > 0) {

      return (
        <div>
          <div>
            <Navbar />
            <p className="text">Search Results</p>
            <SearchForm></SearchForm>
            <br/>
            <br/>
            <div className="cardText">
              <div class="wrapper-four-col">
                <PrimeCard />
              </div>
            </div>
          </div>
        </div>
      )
    }
    else {
      return (
        <div>
          <div className="app">
            <Navbar />
            <div>
            </div>
            <div className="container">
              <div className="text">
                Enter the username/partial username to search for the GIT user
              </div>
              <SearchForm ></SearchForm>
            </div>

          </div>
          <br />
          <br />
          <div className="bg">
            <img src={img} alt="cannot display" />
          </div>
        </div>
      );
    }
  }
}


export default observer(App);
