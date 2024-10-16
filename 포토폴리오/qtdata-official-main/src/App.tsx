import { Route, Routes } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import Home from "./pages/home/Home";
import About from "./pages/about/About";
import Neos from "./pages/joosikbox/Neos";
import Contents from "./pages/contents/Contents";
import Contact from "./pages/contact/Contact";
import Recruit from "./pages/recruit/Recruit";

function App() {
  return (
    <Routes>
      <Route element={<MainLayout />}>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/joosikbox" element={<Neos />} />
        <Route path="/press" element={<Contents />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/recruit" element={<Recruit />} />
      </Route>
    </Routes>
  );
}

export default App;
