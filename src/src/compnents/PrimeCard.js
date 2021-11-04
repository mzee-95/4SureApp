import "primeicons/primeicons.css";
import "primereact/resources/themes/md-light-indigo/theme.css";
import "primereact/resources/primereact.css";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { Toast } from 'primereact/toast';

import axios from 'axios';
import React from "react";
import userStore from '../stores/userStore';
import UserActivity from "../stores/UserActivity";
import SubmitButton from "../SubmitButton";

class PrimeCard extends React.Component {
  constructor(props) {
    super(props);
    this.header = (
      <img src="../assets/user-svgrepo-com.svg" 
        onError={
          (e) => (e.target.src = "../assets/user-svgrepo-com.svg")
        }
      />
    );
  }
  render() {
    return (
      userStore.users.map((user, index) =>
        <div class="column" >
          <Card
            title={user.login}
            subTitle={user.followers}
            header={user.avatar}
            style={{ width: "25em"  },{'background-color': 'grey'}, {'text-transform': 'uppercase'}}

          >
             <p className="p-m-0" style={{ lineHeight: "1.5" }}>
              Click to view the activities for <b><u>{user.login}</u></b>. 
            </p> 

            <SubmitButton text='View User Activity' label="View" icon="pi pi-search" onClick={() => UserActivity.loadActivity(user.login)} />
          </Card>
        </div >
      )
    );
  };
}
export default PrimeCard;
