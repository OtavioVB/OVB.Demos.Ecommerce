import "./SeparatorHorizontal.css";

export default function SeparatorHorizontal(props){
    if(props.Text != null){
        return (
            <div className="component-content-separator-separator-horizontal-with-text">
                <span className="component-separator-horizontal-with-text"></span>
                <p className="component-text-for-separator-horizontal">{props.Text}</p>
                <span className="component-separator-horizontal-with-text"></span>
            </div>
        );
    }

    return (
        <span className="component-separator-horizontal"></span>
    );
}