import { useState } from "react";
import {
  Micon,
  MobileIcon,
  MobileMenu,
  MobileMenuItem,
  MobileMenuLogo,
} from "../../styles/header/mobileNavStyle";
import { NavLink, useLocation } from "react-router-dom";
import { theme } from "../../themes/themes";
import { IPath } from "./../../types/navTypes";
import { NavMenus } from "../../datas/navItems";

const MobileNav = () => {
  const [nav, setNav] = useState(false);

  const location = useLocation();

  const handleClick = () => {
    setNav(!nav);
  };
  return (
    <>
      <MobileIcon onClick={handleClick}>
        {nav ? (
          <Micon src="/assets/close.svg" alt="close" />
        ) : (
          <Micon src="/assets/menu.svg" alt="menu" />
        )}
      </MobileIcon>

      <MobileMenu className={nav ? "visible" : ""}>
        <div>
          <MobileMenuLogo />
        </div>
        {NavMenus.map((item, index) => (
          <MobileMenuItem key={index}>
            {typeof item === "object" ? (
              <>
                <NavLink
                  onClick={handleClick}
                  to={(item as IPath).path}
                  className={`nav-link ${
                    location.pathname === (item as IPath).path ? "active" : ""
                  }`}
                  style={{
                    color:
                      location.pathname === (item as IPath).path
                        ? theme.colors.sub
                        : "",
                  }}
                >
                  {(item as IPath).label}
                </NavLink>
              </>
            ) : (
              item
            )}
          </MobileMenuItem>
        ))}
      </MobileMenu>
    </>
  );
};

export default MobileNav;
