import './ButtonRedirection.css';
import React from 'react';

export default function ButtonRedirection(props){
    return (
        <a href={props.Href} className="component-form-link-others-links">{props.Value}</a>
    );
}