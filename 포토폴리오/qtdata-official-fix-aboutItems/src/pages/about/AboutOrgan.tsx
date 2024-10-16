import Head from "../../components/commons/Headline/Head";
import {
  MOrganImg,
  OrganBox,
  OrganImg,
  OrganWrap,
} from "../../styles/about/aboutOrganStyle";

const AboutOrgan = () => {
  return (
    <OrganWrap>
      <Head content="Organization" color="sub" />
      <OrganBox>
        <OrganImg src="/assets/organization.png" alt="organization" />
        <MOrganImg src="/assets/organizationM.png" alt="organization" />
      </OrganBox>
    </OrganWrap>
  );
};

export default AboutOrgan;
