import {BrowserRouter as Router, Route, Routes} from 'react-router-dom'
import NotFound from './routes/NotFound/NotFound.js';
import LandingPage from './routes/LandingPage/LandingPage.js';

export default function App(){
    return (
        <Router>
            <Routes>
                <Route exact path="/" caseSensitive={false} element={<LandingPage/>}></Route>
                <Route path="*" element={<NotFound/>}/>
            </Routes>
        </Router>
    );
}