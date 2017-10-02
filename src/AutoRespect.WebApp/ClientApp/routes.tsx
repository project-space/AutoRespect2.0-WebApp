import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Auth from './components/Auth';
import Home from './components/Home';

export const routes = <Layout>
    <Route exact path='/' component = { Auth } />
</Layout>;
