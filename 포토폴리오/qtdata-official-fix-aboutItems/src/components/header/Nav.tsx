import React from "react";
import { NavBar, NavList, NavUl } from "../../styles/header/navStyle";
import { NavLink, useLocation } from "react-router-dom";
import { theme } from "../../themes/themes";
import { IPath } from "../../types/navTypes";
import { NavMenus } from "../../datas/navItems";

const Nav = () => {
  const location = useLocation();

  return (
    <NavBar>
      <NavUl>
        {NavMenus.map((item, index) => (
          <NavList key={index}>
            {typeof item === "object" ? (
              <>
                <NavLink
                  to={(item as IPath).path}
                  className={`nav-link ${
                    location.pathname === (item as IPath).path ? "active" : ""
                  }`}
                  style={{
                    margin: "12px",
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
          </NavList>
        ))}
      </NavUl>
    </NavBar>
  );
};

export default Nav;
