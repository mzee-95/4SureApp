import React from 'react';
import InputField from './InputField'
import SubmitButton from './SubmitButton'
import userStore from './stores/userStore'
import axios from 'axios';
import { InputText } from 'primereact/inputtext';
import ConnectionStore from './stores/ConnectionStore';

class SearchForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            username: '',
            buttonDisable: false
        }
    }

    getStoredData() {
        let dataString = localStorage.getItem('searchUserResults');
        let data = JSON.parse(dataString);
        userStore.updateStateItems(data, true);
        ConnectionStore.UserSearchOffline(true);
    }

    setInputValue(property, val) {
        val = val.trim();
        if (val.length > 20) {
            return;
        }
        this.setState({
            [property]: val
        })
    }

    resetForm() {
        this.setState({
            username: '',
            buttonDisable: false
        })
    }

    async doSearch() {
        if (!this.state.username) {
            return;
        }
        this.setState({
            buttonDisable: true
        })

        try {
            ConnectionStore.SetIsLoading(true);
            let res = await axios.post(
                "https://localhost:5001/search/SearchUsers?username=" + this.state.username,
                JSON.stringify({
                    username: this.state.username
                }), {
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS'
                }
            }
            ).then(resp => {
                if (resp.status === 202 || resp.status === 200) {
                    try {
                        userStore.updateStateItems(resp.data, false);
                        ConnectionStore.UserSearchOffline(false);
                    }
                    catch (e) {
                        //we were unalbe
                        this.getStoredData()
                        ConnectionStore.UserSearchOffline(true);
                    }
                }
                else {
                    this.getStoredData();
                    ConnectionStore.UserSearchOffline(true);

                }
            }).catch(error => {
                ConnectionStore.UserSearchOffline(true);
                this.getStoredData()
                console.log(error);
            });


        }
        catch (e) {
            this.getStoredData()
            console.log(e);
            this.resetForm();
        }
        finally {
            ConnectionStore.SetIsLoading(false);
          }
        console.log(userStore);
    }

    render() {
        return (
            <div className="searchForm">
                <InputField
                    type='text'
                    placeholder='Username'
                    value={this.state.username ? this.state.username : ''}
                    onChange={(val) => this.setInputValue('username', val)}
                />
                <SubmitButton
                    text='Search'
                    disabled={this.state.buttonDisable}
                    onClick={() => this.doSearch()}
                />
            </div>
        );
    }
}


export default SearchForm;
