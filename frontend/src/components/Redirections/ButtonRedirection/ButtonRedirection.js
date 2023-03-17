import './ButtonRedirection.css';
import React from 'react';
import { Link } from 'react-router-dom';

export default function ButtonRedirection(props){
    return (
        <Link to={props.Href} className="component-form-link-others-links">{props.Value}</Link>
    );
}