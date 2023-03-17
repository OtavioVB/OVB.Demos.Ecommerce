import {BrowserRouter as Router, Route, Routes} from 'react-router-dom'
import NotFound from './routes/NotFound/NotFound.js';
import LandingPage from './routes/LandingPage/LandingPage.js';
import ServerStatus from './routes/Server/Status/ServerStatus.js';
import Authentication from './routes/Authentication/Authentication.js';
import CompanyCreate from './routes/Authentication/Company/CompanyCreate/CompanyCreate.js';
import CompanyLogin from './routes/Authentication/Company/CompanyLogin/CompanyLogin.js';
import MemberCreate from './routes/Authentication/Member/MemberCreate/MemberCreate.js';

export default function App(){
    return (
        <Router>
            <Routes>
                <Route exact path="/authentication/" caseSensitive={false} element={<Authentication/>}></Route>
                <Route exact path="/authentication/create" caseSensitive={false} element={<MemberCreate/>}></Route>
                <Route exact path="/authentication/company/create" caseSensitive={false} element={<CompanyCreate/>}></Route>
                <Route exact path="/authentication/company/login" caseSensitive={false} element={<CompanyLogin/>}></Route>
                <Route exact path="/server/status" caseSensitive={false} element={<ServerStatus/>}></Route>
                <Route exact path="/" caseSensitive={false} element={<LandingPage/>}></Route>
                <Route path="*" element={<NotFound/>}/>
            </Routes>
        </Router>
    );
}