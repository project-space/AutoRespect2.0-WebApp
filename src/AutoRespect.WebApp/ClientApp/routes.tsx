import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import Authorization from "./components/Authorization";

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/auth' component = { Authorization } />
</Layout>;
