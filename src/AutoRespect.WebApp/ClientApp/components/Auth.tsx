import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
    
export default class Auth extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div className='auth-container'>
            <div className='auth-form'>
                <header>
                    <h1>auto respect 2.0</h1>
                    <h2>Авторизация</h2>
                </header>
                <content>
                    <div>
                        <input placeholder = 'Логин'/>
                    </div>
                    <div>
                        <input type='password' placeholder = 'Пароль'/>
                    </div>

                    <button>Войти</button>
                </content>
            </div>
        </div>;
    }
}
