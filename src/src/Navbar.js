import React, { useState } from 'react';
import userStore from './stores/userStore';
import ConnectionStore from './stores/ConnectionStore';
import UserActivity from './stores/UserActivity';



class Navbar extends React.Component {
    resetToHome(){
        userStore.reset();
        ConnectionStore.reset();
        UserActivity.reset();
    }
    render() {
        return (
            <div>
                <ul id="nav">
                    <li><a href="#" >Welcome to Git Search</a></li>
                </ul>
            </div>
        );
    }
}

export default Navbar;