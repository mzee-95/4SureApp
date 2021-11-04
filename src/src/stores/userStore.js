import { extendObservable } from 'mobx'
import React from 'react';


//userStore

class userStore extends React.Component {
    constructor() {
        super();
        extendObservable(this, {
            users: []
        })
    }
    updateStateItems = (data, offline) => {
        if (data != null) {
            if (offline) {
                this.users = data
            } else {
                this.users = data.users
                localStorage['searchUserResults'] = JSON.stringify(this.users);
            }
        }
    }
    reset() {
        this.users = []
    }
}

export default new userStore();