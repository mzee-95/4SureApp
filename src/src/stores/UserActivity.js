import { extendObservable } from 'mobx'
import React from 'react';
import axios from 'axios';
import LoaderStore from './ConnectionStore';
import ConnectionStore from '../stores/ConnectionStore';
//userStore

class UserActivity extends React.Component {

  //const users:[]
  constructor() {
    super();
    extendObservable(this, {
      users: {},
      activities: [],
      showModal: false
    })

 
  }
  reset(){
    this.users= {};
    this.activities= [];
    this.showModal= false;
  }

  getStoredData() {
    let dataString = localStorage.getItem('acivitySearchResults');
    let data = JSON.parse(dataString);
    let user = data.users;
    let activity = data.activities;
    this.updateStateItems(user, activity, data, false);
    ConnectionStore.SetIsLoading(true);
  }


  updateStateItems = (username, activities, data, update) => {
    this.users = username;
    this.activities = activities;
    this.showModal = true;
    if (update)
      localStorage['acivitySearchResults'] = JSON.stringify(data);
  }
  async loadActivity(login) {
    ConnectionStore.SetIsLoading(true);
    try {
      let res = await axios.post(
        "https://localhost:5001/search/SearchUserActivity?username=" + login,
        JSON.stringify({
          username: login
        }), {
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS'
        }
      }
      ).then(resp => {
        if (resp.status === 202 || resp.status === 200) {
          try {
            this.updateStateItems(resp.data.user, resp.data.activities, resp.data, true)
            ConnectionStore.ActivitySearchOffline(false);
          }
          catch (e) {
            this.getStoredData()
          }
        }
        else {
          this.getStoredData();
          ConnectionStore.ActivitySearchOffline(false);
        }
      }).catch(error => {
        this.getStoredData()
        console.log(error.msg);
      });


    }
    catch (e) {
      this.getStoredData()
      console.log(e);

    }
    finally {
      ConnectionStore.SetIsLoading(false);
    }
  }

  render() {
    return (
      <div>{this.activities}</div>
    )
  }
}

export default new UserActivity();