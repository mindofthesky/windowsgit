import Nav from "./Nav";
import {
  HeaderContainer,
  HeaderLayout,
  HeaderLogo,
  HeaderNav,
} from "../../styles/header/header";
import MobileNav from "./MobileNav";
// import NavLang from "./NavLang";

const Header = () => {
  return (
    <HeaderLayout>
      <HeaderContainer>
        <a href="/">
          <HeaderLogo></HeaderLogo>
        </a>
        <HeaderNav>
          <Nav />
        </HeaderNav>
        {/* <NavLang /> */}
        <MobileNav />
      </HeaderContainer>
    </HeaderLayout>
  );
};

export default Header;
