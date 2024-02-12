import Link from '@/components/link/link';

const Navbar = () => {
  return (
    <nav className="relative px-4 py-4 flex justify-between items-center bg-white shadow-sm">
      <a className="text-3xl font-bold leading-none" href="/">
        UKS Git
      </a>
      <Link
        linkVariation="secondary"
        content="Sign in"
        className="ml-auto mr-3"
        href="/login"
      />
      <Link linkVariation="primary" content="Sign up" href="/registration" />
    </nav>
  );
};

export default Navbar;
